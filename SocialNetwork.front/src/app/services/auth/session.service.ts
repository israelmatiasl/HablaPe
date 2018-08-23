import { Injectable } from '@angular/core';
import { SessionReq, SessionRes, RegisterReq, RegisterRes } from '../../models/account.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { API_URL } from "../../helpers/constants";
import { MenuResponse } from '../../models/menu.model';

@Injectable()
export class SessionService {

  constructor(private _http:HttpClient,  private _router:Router) { }

  createSession(sessionReq:SessionReq){
    let url = `${API_URL}/signin`;
    return this._http.post(url, sessionReq).map((response:any) => {
      if(response.success){
        this.saveSession(response.session);
        this.saveMenu(response.menuResponse);
        return true;
      }
      else{
        return false;
      }
    });
  }

  registerAccount(register:RegisterReq){
    let url = `${API_URL}/register`;
    return this._http.post(url, register).map((response:RegisterRes) => {
      return response;
    });
  }

  deleteSession(){
    localStorage.removeItem('session');
    localStorage.removeItem('menu');
    this._router.navigate(['/auth']);
  }

  saveSession(session:SessionRes){
    localStorage.setItem('session', JSON.stringify(session));
  }

  saveMenu(menuReponse:MenuResponse){
    localStorage.setItem('menu', JSON.stringify(menuReponse));
  }

  getSession(){
    let session = null;
    if(localStorage.getItem('session')){
      let sessionRes:SessionRes = JSON.parse(localStorage.getItem('session'));
      session = new SessionRes(null, sessionRes.name, sessionRes.lastname, sessionRes.nick,
                               sessionRes.birthday, sessionRes.gender, sessionRes.photo, null );
    }
    return session;
  }

  getToken(){
    let token = null;
    if(localStorage.getItem('session')){
      token = JSON.parse(localStorage.getItem('session')).token;
    }
    return token;
  }

  isLoggedIn() {
    return (this.getSession()) ? true : false;
  }
}
