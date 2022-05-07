import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { shareReplay } from 'rxjs/operators';
import { IMessage } from '../models/message';

@Injectable({
  providedIn: 'root'
})

export class MessagesService {
  protected messages$ = new Subject<IMessage>();

  constructor() { }

  fetch():Observable<IMessage> {
    return this.messages$.pipe(shareReplay());
  }

  send(message: IMessage):Observable<unknown> {
    this.messages$.next(message);
    return of(message);
  }
}
