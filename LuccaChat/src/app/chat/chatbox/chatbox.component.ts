import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { finalize, take } from 'rxjs/operators';
import { IMessage } from '../../messages/models/message';
import { MessagesService } from '../../messages/services/messages.service';

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.scss']
})
export class ChatboxComponent implements OnInit, OnDestroy {
  subscription:Subscription;

  messages: IMessage[] = [];
  textMessage: string = '';

  @Input() id: number;

  constructor(private messageService: MessagesService) { }

  ngOnInit(): void {
    this.subscription = this.messageService
      .fetch()
      .subscribe({
        next: (message) => this.messages.push(message),
        error: (err) => {},
      });
  }

  ngOnDestroy(): void {
      if(this.subscription) this.subscription.unsubscribe();
  }

  send(){
    if (this.textMessage === '') return;

    let message: IMessage  = {
      sender: this.id,
      textMessage: this.textMessage,
      date: new Date()
    };
    this.messageService.send(message)
    .pipe(
      take(1),
      finalize(() => {
        this.textMessage = '';
      }),
      )
    .subscribe({
      error:(err) => {console.log('oups')} 
    });
  }
}
