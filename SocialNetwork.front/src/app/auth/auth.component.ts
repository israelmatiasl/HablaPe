import { Component, OnInit } from '@angular/core';
import { RegisterReq, SessionReq, RegisterRes } from '../models/account.model';
import { NgForm } from '@angular/forms';
import { SessionService } from '../services/services.index';
import { Router } from '@angular/router';
import swal from 'sweetalert2'

declare function init_app();

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html'
})
export class AuthComponent implements OnInit {

  public register:RegisterReq;
  public session:SessionReq;
  public invalidSession:boolean = false;

  constructor(private authService:SessionService, private _router:Router) {
    this.register = new RegisterReq('', '', '', '', '', '', false);
    this.session = new SessionReq('', '', false);
  }

  ngOnInit() {
    init_app();
  }

  Session(form:NgForm){
    if(form.invalid) return;
    this.authService.createSession(this.session).subscribe((res:boolean) =>{
      if(res){
        this._router.navigate(['/home']);
        this.invalidSession = false;
      }
      else {
        this.invalidSession = true;
      }
    });
  }

  RegisterAccount(form:NgForm){
    if(form.invalid || !this.register.agree) return;
    this.authService.registerAccount(this.register).subscribe((res:RegisterRes) => {
      if(res.success){
        swal({
          title: 'En hora buena!',
          text: 'Su cuenta ha sido creado correctamente. Por favor revise su email para verificar su cuenta.',
          type: 'success',
        })
      }
    });
  }
}
