import { Component, OnInit } from '@angular/core';
import { RegisterReq, SessionReq } from '../models/account.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SessionService } from '../services/services.index';
import { Router } from '@angular/router';
import { NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
import { validateAllFormFields } from '../helpers/functions'
import { BodyResponse, Alert } from '../models/response.model';
import { Cypher } from '../helpers/cypher';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html'
})

export class AuthComponent implements OnInit {

  public registerForm:FormGroup;
  public loginForm:FormGroup;
  currentJustify = 'justified';
  public sessionLoading = false;
  public registerLoading = false;
  public alert:Alert;



  constructor(private authService:SessionService, private config: NgbDatepickerConfig, private _router:Router) {
    this.config.minDate = {year: 1970, month: 1, day: 1};
    this.config.maxDate = {year: new Date().getFullYear() - 13, month: 12, day: 31};

    this.alert = new Alert('', false, '', '', 0);
  }

  ngOnInit() {
    this.registerForm = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      lastname: new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(30)]),
      birthday: new FormControl(null, [Validators.required]),
      gender: new FormControl('', [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email, Validators.maxLength(40)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(8), Validators.maxLength(50)]),
      agree: new FormControl(false , [Validators.requiredTrue])
    });
    
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email, Validators.maxLength(40)]),
      password: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      remember: new FormControl(false)
    });
  }

  Session(){
    if(this.loginForm.invalid){
      validateAllFormFields(this.loginForm);
    }
    else {
      let formBody = this.loginForm.controls;
      let password = Cypher.Encrypt(formBody.password.value).toString();
      let formLogin = new SessionReq(formBody.email.value, password, formBody.remember.value);
      this.sessionLoading = true;

      this.authService.createSession(formLogin).subscribe((res:any) => {
        setTimeout(()=> {
          if (!res.success) { 
            this.showAlert('session', res.message, res.success);
          }
          else {
            this._router.navigate(["/home"]);
          }
          this.sessionLoading = false;
        }, 2000);
      }, (err) => {
        this.showAlert('session', 'Internal error', false);
        this.sessionLoading = false;
      });
    }
  }

  RegisterAccount(){
    if(this.registerForm.invalid){
      validateAllFormFields(this.registerForm);
    }
    else{
      try {
        let date = this.registerForm.controls.birthday.value;
        let formBody = this.registerForm.controls;
        let password = Cypher.Encrypt(formBody.password.value).toString();
        let formRegister = new RegisterReq(formBody.name.value, formBody.lastname.value, formBody.gender.value,
                                           `${date.day}-${date.month}-${date.year}`, formBody.email.value,
                                            password, formBody.agree.value);
        this.registerLoading = true;
        this.authService.registerAccount(formRegister).subscribe((res:BodyResponse) => {
          setTimeout(()=> {
            if(!res.success) {
              this.showAlert('register', res.message, res.success);
            }
            else {
              this.showAlert('register', res.message, res.success, 15000);
              this.registerForm.reset();
            }
            this.registerLoading = false;
          }, 2000);
        }, (err) => {
          this.showAlert('register', 'Internal error', false);
          this.registerLoading = false;
        });
      }
      catch{
        this.showAlert('register', 'Client error', false);
        this.registerLoading = false;
      }
    }
  }

  showAlert(owner:string, message:string, isSuccess:boolean, duration:number = 4000){
    let type = (isSuccess ? 'success': 'error');
    this.alert = new Alert(owner, true, type, message, duration);
    setTimeout(()=> {
      this.alert = new Alert('', false, '', '', 0);
    }, duration);
  }

  isFieldInvalid(field: string, fG:FormGroup) {
    return !fG.get(field).valid && fG.get(field).touched;
  }

  getFieldError(field: string, fG:FormGroup){
    return fG.get(field);
  }
  
  displayFieldCss(field: string, fG:FormGroup) {
    return { 'is-invalid': this.isFieldInvalid(field, fG)};
  }

  tabChange(tab:any){
    if(tab.nextId == 'tab-signup') {
      this.loginForm.reset();
    }
    else if(tab.nextId == 'tab-login') {
      this.registerForm.reset();
    }
  }
}
