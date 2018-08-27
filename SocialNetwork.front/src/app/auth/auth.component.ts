import { Component, OnInit } from '@angular/core';
import { Register, RegisterReq, SessionReq } from '../models/account.model';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';
import { SessionService } from '../services/services.index';
import { Router } from '@angular/router';
import { NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html'
})

export class AuthComponent implements OnInit {

  public fGroup:FormGroup;
  currentJustify = 'justified';
  public register:Register;
  public session:SessionReq;
  public sessionLoading = false;
  public registerLoading = false;
  public alertClosed = true;
  public alertMessage:string;

  constructor(private authService:SessionService, private config: NgbDatepickerConfig, private _router:Router) {
    this.config.minDate = {year: 1970, month: 1, day: 1};
    this.config.maxDate = {year: new Date().getFullYear() - 13, month: 12, day: 31};

    this.session = new SessionReq('', '', false);
  }

  ngOnInit() {
    this.fGroup = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      lastname: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      birthday: new FormControl(null, [Validators.required]),
      gender: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email, Validators.minLength(4)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8), Validators.maxLength(50)]),
      agree: new FormControl(false)
    }, { validators: this.validGender('gender' )} );
  }

  validGender(gender:string){
    return (group: FormGroup) => {
      let validGenders = ['male', 'female'];
      let field = group.controls[gender].value;
      if(validGenders.indexOf(field) > -1){
        return null;
      }
      else{
        return { notValid: true }
      }
    };
  }

  Session(form:NgForm){
    if(form.invalid) return;
    this.sessionLoading = true;
    this.authService.createSession(this.session).subscribe((res:any) => {
      setTimeout(()=> {
        if (!res.success) { this.autoCloseAlert(res.message); }
        else {
          this._router.navigate(["/home"]);
        }
        this.sessionLoading = false;
      }, 2000);
    }, (err) => {
      this.autoCloseAlert(err.error);
      this.sessionLoading = false;
    });
  }

  autoCloseAlert(message:string){
    this.alertClosed = false;
    this.alertMessage = message;
    setTimeout(()=> {
      this.alertClosed = true;
      this.alertMessage = null;
    }, 4000);
  }

  RegisterAccount(){
    console.log(this.fGroup)
  }
}
