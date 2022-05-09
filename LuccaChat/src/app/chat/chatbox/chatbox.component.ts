import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { Subscription } from 'rxjs';
import { finalize, take } from 'rxjs/operators';
import { IMessage } from '../../messages/models/message';
import { MessagesService } from '../../messages/services/messages.service';

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.scss'],
})
export class ChatboxComponent implements OnInit, OnDestroy {
  subscription: Subscription;

  @Input() id: number;
  @Output() closeWindow: EventEmitter<number> = new EventEmitter<number>();

  messages: IMessage[] = [];
  textMessage: string = '';
  error: string = '';

  constructor(private messageService: MessagesService) {}

  ngOnInit(): void {
    this.subscription = this.messageService.fetch().subscribe({
      next: (message) => {
        this.messages.push(message);
      },
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) this.subscription.unsubscribe();
  }

  send(): void {
    if (this.textMessage === '') return;
    let message: IMessage = {
      sender: this.id,
      textMessage: this.textMessage,
      date: new Date(),
    };

    this.messageService
      .send(message)
      .pipe(
        take(1),
        finalize(() => {
          this.textMessage = '';
        })
      )
      .subscribe({
        error: (err) => {
          this.error = "Une erreur est survenue lors de l'envoi du message";
        },
      });
  }

  close(): void {
    this.closeWindow.emit(this.id);
  }
}
