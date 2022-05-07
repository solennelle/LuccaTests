import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatboxComponent } from './chatbox/chatbox.component';
import { MatIconModule } from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ChatboxComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatDividerModule, 
    FormsModule
  ],
  exports: [ChatboxComponent]
})
export class ChatModule { }
