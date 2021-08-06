import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IMember } from '../../Models/IMember';
import { MemberService } from '../../Services/member.service';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  public members: Observable<IMember[]>;

  constructor(private memberService: MemberService) { }

  public ngOnInit(): void {
    this.members = this.memberService.getMembers();

  }


 }

