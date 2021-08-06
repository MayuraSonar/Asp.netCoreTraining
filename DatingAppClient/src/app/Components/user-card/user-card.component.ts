import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IMember } from 'src/app/Models/IMember';
import { MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css'],
})
export class UserCardComponent implements OnInit {
  @Input() public member: IMember;
  constructor(private memberService: MemberService, private toastr: ToastrService) { }

  public ngOnInit(): void {

  }
  public addLike(member: IMember) {
    this.memberService.addLike(member.id).subscribe(() => {

      this.toastr.success('you have  liked  ' + member.name);
    },
     (error) => this.toastr.error('You have already liked this user!!!'));
  }
}
