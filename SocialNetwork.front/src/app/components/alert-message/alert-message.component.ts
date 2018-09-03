import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-alert-message',
  templateUrl: './alert-message.component.html',
  styles: []
})
export class AlertMessageComponent implements OnInit {

  public showAlert:boolean = true;
  @Input() type:string;
  @Input() message:string;
  @Input() duration:number = 3000;
  

  constructor() { }

  ngOnInit() {
    this.autoCloseAlert();
  }

  autoCloseAlert(){
    this.showAlert = true;
    setTimeout(() => {
      this.showAlert = false;
      this.message = null;
    }, this.duration);
  }

  isError(type:string){
    if(type == 'error'){ return true; }
    else {  return false; }
  }

  getStyleAlert(type:string){
    return { 'alert-danger': this.isError(type), 'alert-success' : !this.isError(type) }
  }
}
