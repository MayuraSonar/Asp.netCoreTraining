import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { IUser } from 'src/app/Models/IUser';
import { AccountService } from 'src/app/Services/account.service';
import { MemberService } from 'src/app/Services/member.service';
import { environment } from 'src/environments/environment';
import { IMember } from '../../Models/IMember';
import { IPhoto } from '../../Models/IPhoto';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent implements OnInit {

  @Input() public member: IMember;
  public user: IUser;
  public uploader: FileUploader;
  public hasBaseDropzoneOver = false;
  public baseUrl = environment.apiUrl;


  constructor(private accountService: AccountService, private memberService: MemberService) {
    this.accountService.currentUser.subscribe((user) => this.user = user);
   }

  public ngOnInit(): void {
    this.initializeUploader();
  }

  public fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }

  public initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'user/add-photos',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo: IPhoto = JSON.parse(response);
        this.member.photos.push(photo);
        if (photo.isMain) {
           this.user.photoUrl = photo.url;
           this.member.photoUrl = photo.url;
           this.accountService.setCurrentUser(this.user);
         }
      }
    };
  }

  public setMainPhoto(photo: IPhoto) {
    this.memberService.setMainPhoto(photo.id).subscribe(() => {
      this.user.photoUrl = photo.url;
      this.member.photoUrl = photo.url;
      this.member.photos.forEach((p) => {
        if (p.isMain) {
          p.isMain = false;
        }
        if (p.id === photo.id) {
          p.isMain = true;
        }
      });

    });
  }
  public deletePhoto(photoId: number) {
    this.memberService.deletePhoto(photoId).subscribe(() => {
      this.member.photos = this.member.photos.filter((x) => x.id !== photoId);
    });
  }
}
