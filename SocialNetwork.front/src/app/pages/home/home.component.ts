import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {

  public publications:any = [
    { publication: {id: 1 },comments: false },
    { publication: {id: 2 }, comments: false},
    { publication: {id: 3 }, comments: false},
    { publication: {id: 4 }, comments: false},
  ];

  constructor() { }

  ngOnInit() {
  }

  showComments(publicationId: number){
    this.publications.forEach((publication)=> {
      if(publication.publication.id == publicationId){
        if(publication.comments == false){
            publication.comments = true;
        }
        else {
          publication.comments = false;
        }
      }
    });
  }
}
