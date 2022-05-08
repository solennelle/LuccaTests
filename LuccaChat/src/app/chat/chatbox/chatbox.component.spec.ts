import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ChatboxComponent } from './chatbox.component';
import { ChatModule } from '../chat.module';
import { MessagesModule } from '../../messages/messages.module';
import { MessagesService } from 'src/app/messages/services/messages.service';
import { of } from 'rxjs';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

describe('ChatboxComponent', () => {
  let component: ChatboxComponent;
  let messagesService: MessagesService;
  let fixture: ComponentFixture<ChatboxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatboxComponent ],
      imports: [
        ChatModule,
        MessagesModule
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatboxComponent);
    messagesService = TestBed.inject(MessagesService);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should send a message', () => {
    component.textMessage = 'test';
    component.id = 1;

    spyOn(messagesService, 'send').and.returnValue(of(undefined));

    component.send();

    expect(messagesService.send).toHaveBeenCalled();
  });

  it('should not send a message if input is empty', () => {
    component.textMessage = '';
    component.id = 1;

    spyOn(messagesService, 'send').and.returnValue(of(undefined));

    component.send();

    expect(messagesService.send).not.toHaveBeenCalled();
  });

  it('should empty message input after sending a message', () => {
    component.textMessage = 'test';
    component.id = 1;

    component.send();

    expect(component.textMessage = '');
  });

  it('should add message to messages array', () => {
    component.textMessage = 'test';
    component.id = 1;

    component.send();

    expect(component.messages[0].textMessage = 'test');
  });
});
