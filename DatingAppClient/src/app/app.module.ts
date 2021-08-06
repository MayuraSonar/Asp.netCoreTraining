import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FileUploadModule } from 'ng2-file-upload';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from 'ngx-gallery-9';
import { ToastrModule } from 'ngx-toastr';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DateInputComponent } from './Components/date-input/date-input.component';
import { HomeComponent } from './Components/home/home.component';
import { ListComponent } from './Components/list/list.component';
import { MessagesComponent } from './Components/messages/messages.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { PhotoEditorComponent } from './Components/photo-editor/photo-editor.component';
import { RegisterComponent } from './Components/register/register.component';
import { TextInputComponent } from './Components/text-input/text-input.component';
import { UserCardComponent } from './Components/user-card/user-card.component';
import { UserDetailsComponent } from './Components/user-details/user-details.component';
import { UserEditComponent } from './Components/user-edit/user-edit.component';
import { UserListComponent } from './Components/user-list/user-list.component';
import { JwtInterceptor } from './Interceptor/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    UserListComponent,
    ListComponent,
    MessagesComponent,
    RegisterComponent,
    HomeComponent,
    UserCardComponent,
    UserDetailsComponent,
    UserEditComponent,
    PhotoEditorComponent,
    DateInputComponent,
    TextInputComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot({ positionClass: 'toast-bottom-left' }),
    TabsModule.forRoot(),
    NgxGalleryModule,
    FileUploadModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),

  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent],
})
export class AppModule { }
