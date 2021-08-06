import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IMember } from 'src/app/Models/IMember';
import { IUser } from 'src/app/Models/IUser';
import { AccountService } from 'src/app/Services/account.service';
import { MemberService } from 'src/app/Services/member.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css'],
})
export class UserEditComponent implements OnInit {
  @ViewChild('editForm') public editForm: NgForm;
  public member: IMember;
  public user: IUser;
  @HostListener('window:beforeunload', ['$event'])  public unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private accountService: AccountService, private memberService: MemberService,
              private toastrService: ToastrService) { }

  public ngOnInit(): void {
    this.accountService.currentUser.subscribe((response) => {
      this.user = response;

    });
    this.loadMembers();
  }

  public loadMembers() {
    this.memberService.getMemberById(this.user.id).subscribe((response) => {
      this.member = response;
    });
  }
  public editUser() {
    this.memberService.updateUser(this.member).subscribe(() => {
      this.toastrService.success('your data has been successfully updated!!');
      this.editForm.reset(this.member);

    });

    console.log(this.member);

  }
}

