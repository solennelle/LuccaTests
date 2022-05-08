import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  users: number[] = [];
  isDisabled: boolean = false;
  maxUsers:number = 4;
  minUsers:number = 2;
  startUsers: number = 2;
  maxUsersMessage: string = `Vous ne pouvez avoir que ${this.maxUsers} fenêtres ouvertes simultanément`;

  constructor() { }

  ngOnInit(): void {
    for (let index = 0; index < this.startUsers; index++) {
      this.users.push(index);
    }
  }
  
  addUser():void {
    if (this.users.length >= this.maxUsers) {
      return;
    }
    let lastUser = this.users[this.users.length - 1];
    this.users.push(++lastUser);
    if (this.users.length >= this.maxUsers) {
      this.isDisabled = true;
    }
  }

  removeUser(id: number): void {
    if (this.users.length <= this.minUsers) {
      return;
    }
    this.users = this.users.filter(e => e !== id);
  }
}
