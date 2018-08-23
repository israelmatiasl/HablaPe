import { Component, OnInit } from '@angular/core';
import { SessionService } from '../../services/services.index';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {

  public name:string;
  public lastname:string;

  constructor(private sessionService:SessionService) { }

  ngOnInit() {
    this.name = JSON.parse(localStorage.getItem('session')).name;
    this.lastname = JSON.parse(localStorage.getItem('session')).lastname;
  }

  logOut(){
    this.sessionService.deleteSession();
  }
}
