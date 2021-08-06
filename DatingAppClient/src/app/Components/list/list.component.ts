import { Component, OnInit } from '@angular/core';
import { IMember } from 'src/app/Models/IMember';
import { MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent implements OnInit {
  public members: Partial<IMember[]>;
  public predicate = 'liked';
  constructor(private memberService: MemberService) { }

  public ngOnInit(): void {

  }
  public getLikes() {
    this.memberService.getLikes(this.predicate).subscribe((response) => {
      this.members = response;
    });
  }
}
