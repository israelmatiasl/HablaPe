import { Component, OnInit } from '@angular/core';
import { Router, ActivationEnd } from '@angular/router';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';

declare function init_app();

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html'
})
export class PagesComponent implements OnInit {

  public showTopHeader:boolean = false;

  constructor(private _router:Router) {
    this.getDataRoute().subscribe( data => {
      if (data.showHeader){
        this.showTopHeader = true;
      }
      else{
        this.showTopHeader = false;
      }
    });
  }

  ngOnInit() {
    init_app();
  }

  getDataRoute(){
    return this._router.events
      .filter( event => event instanceof ActivationEnd )
      .filter( (event:ActivationEnd) => event.snapshot.firstChild == null )
      .map( (event:ActivationEnd)=> event.snapshot.data )
  }

}
