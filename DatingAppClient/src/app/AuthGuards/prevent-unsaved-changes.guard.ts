import { Injectable } from '@angular/core';
import {  ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserEditComponent } from '../Components/user-edit/user-edit.component';

@Injectable({
  providedIn: 'root',
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  public canDeactivate(
    component: UserEditComponent): boolean {
    if (component.editForm.dirty)
    {
      return confirm('Are you sure u want to continue? Any unsaved Changes will be lost!!!');
      }
    return true;
  }

}
