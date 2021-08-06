import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from './AuthGuards/authentication.guard';
import { PreventUnsavedChangesGuard } from './AuthGuards/prevent-unsaved-changes.guard';
import { HomeComponent } from './Components/home/home.component';
import { ListComponent } from './Components/list/list.component';
import { MessagesComponent } from './Components/messages/messages.component';
import { UserCardComponent } from './Components/user-card/user-card.component';
import { UserDetailsComponent } from './Components/user-details/user-details.component';
import { UserEditComponent } from './Components/user-edit/user-edit.component';
import { UserListComponent } from './Components/user-list/user-list.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthenticationGuard],
    children: [
      { path: 'user', component: UserListComponent },
       {path: 'user/:id', component: UserDetailsComponent},
       {path: 'users/edit', component: UserEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      { path: 'messages', component: MessagesComponent },
      { path: 'lists', component: ListComponent },
    ],
  },

  {path: '**', component: MessagesComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
