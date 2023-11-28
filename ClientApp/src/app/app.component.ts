import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./components/nav/nav.component";
import { HomeComponent } from "./components/home/home.component";
import { AccountService } from './services/accountService';
import { HttpClientModule } from '@angular/common/http';
import { User } from './models/user';
import { ListComponent } from "./components/list/list.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    providers: [AccountService],
    imports: [HttpClientModule, CommonModule, RouterOutlet, NavComponent, HomeComponent, ListComponent]
})
export class AppComponent {
  title = 'Todo list';
  isSignIn = false;
  constructor(public accountService: AccountService) {

  }
  ngOnInit(): void {
    this.setCurrentUser();
  }


  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString){
      return;
    }
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
