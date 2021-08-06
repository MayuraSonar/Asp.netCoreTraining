
import { Component, OnInit } from '@angular/core';
import { IUser } from './Models/IUser';
import { AccountService } from './Services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public title = 'DatingAppClient';
  public displayedColumns: string[] = ['id', 'userName']; public users: any;
  constructor(private accountService: AccountService) {

  }
  public ngOnInit() {
    this.setCurrentUser();
  }

  public setCurrentUser() {
    const user: IUser = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

}