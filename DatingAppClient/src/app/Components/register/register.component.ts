
import { ThrowStmt } from '@angular/compiler';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() public cancelRegister = new EventEmitter();
public model: any = {};
  public registerForm: FormGroup;
  public maxDate: Date;
  public validationErrors: string[] = [];

  constructor(private accountService: AccountService, private toastr: ToastrService,
              private fb: FormBuilder, private router: Router) { }

  public ngOnInit(): void {
    this.intitializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  public intitializeForm() {
    this.registerForm = this.fb.group({
      gender: ['male'],
      name: ['', Validators.required],
      knownAs: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required,
      Validators.minLength(4), Validators.maxLength(8)]],

    });
  }

  public register() {
    console.log(this.registerForm.value);
    this.accountService.register(this.registerForm.value).subscribe((response) => {
      this.router.navigateByUrl('/user');
    }, (error) => {
      this.validationErrors = error;
    });
  }

  public cancel() {
    this.cancelRegister.emit(false);
  }
}
