import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

import { IMember } from 'src/app/Models/IMember';
import { MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css'],
})
export class UserDetailsComponent implements OnInit {

  public member: IMember;
  public galleryOptions: NgxGalleryOptions[];
  public galleryImages: NgxGalleryImage[];
  constructor(private memberService: MemberService, private route: ActivatedRoute) { }

  public ngOnInit(): void {
    this.getMember();
    this.galleryOptions = [
      {
        height: '500px',
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
        thumbnailsColumns: 4,
        width: '500px',

      },
    ];

 
  }

  // get Images out of member object
  public getImages(): NgxGalleryImage[] {
    const imageUrl = [];
    for (const photo of this.member.photos) {
      imageUrl.push({
        big: photo.url,
        medium: photo.url,
        small: photo.url,
          });
      return imageUrl;
      }
  }
  // tslint:disable-next-line: typedef
  public getMember() {
    this.memberService.getMemberById(+this.route.snapshot.paramMap.get('id')).subscribe((response) => {
      console.log(response);
      this.member = response;
      this.galleryImages = this.getImages();

    });
  }
}
