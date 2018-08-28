import { Component, OnInit, Input } from '@angular/core';
import { getMessageValidation } from '../../helpers/functions'

@Component({
  selector: 'app-validators',
  templateUrl: './validators.component.html',
  styles: [`
    .error-msg {
      color: #dc3545;
      font-size: 12px;
    }
  `]
})
export class ValidatorsComponent implements OnInit {

  @Input() field: string;
  @Input() error: any;

  constructor() { }

  ngOnInit() {
  }

  getTotalMessage(type:string){
    return getMessageValidation(this.field, type);
  }
}
