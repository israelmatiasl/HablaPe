import { Component, OnInit } from '@angular/core';

declare var $:any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    window.onscroll = function() {headerFixed()};

    var header = document.getElementById("header-fixed");
    var sticky = header.offsetTop;

    function headerFixed() {
      if (window.pageYOffset > sticky) {
        header.classList.add("if-fixed");
      } else {
        header.classList.remove("if-fixed");
      }
    }
  }

}
