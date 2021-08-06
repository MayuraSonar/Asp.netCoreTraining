import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../Services/account.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationGuard implements CanActivate {
  constructor(private accountService: AccountService, private toastrService: ToastrService) {

  }
  public canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean>  {
    return this.accountService.currentUser.pipe(
      map(((user) => {
        if (user) {
          return true;
        } else {
          this.toastrService.error('You cannot access this page!!');
          }
      })),
    );
  }
  }


