import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../Services/account.service';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  public model: any = {};
  constructor(public accountService: AccountService,
              private toastrService: ToastrService, private router: Router) { }

  public ngOnInit(): void {
  }
  public login() {
    this.accountService.login(this.model).subscribe((response) => {

      console.log(response);
      this.router.navigateByUrl('/user');

    }, (error) => {
        console.log(error);
        this.toastrService.error(error.error);
    });
  }
  public logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');

  }
}
