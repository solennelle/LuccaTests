import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  users: number[] = [];
  constructor() { }

  ngOnInit(): void {
    for (let index = 0; index < 2; index++) {
      this.users.push(index);
    }
  }
}
