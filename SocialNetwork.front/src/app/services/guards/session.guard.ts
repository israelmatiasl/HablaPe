import { Injectable } from "@angular/core";
import { Router, CanActivate } from "@angular/router";

import { SessionService } from '../auth/session.service';

@Injectable()
export class SessionGuard implements CanActivate {

  constructor(private _router:Router, private _sessiontService:SessionService){
  }

  canActivate()  {
    if(this._sessiontService.isLoggedIn()){
      return true;
    }
    else {
      this._router.navigate(['/auth']);
      return false;
    }
  }
}