import { FormGroup, FormControl } from "@angular/forms";

export function toInteger(value: any): number {
    return parseInt(`${value}`, 10);
  }
  
export function isNumber(value: any): value is number {
    return !isNaN(toInteger(value));
}
  
export function padNumber(value: number) {
    if (isNumber(value)) {
      return `0${value}`.slice(-2);
    } else {
      return '';
    }
}


export function validateAllFormFields(formGroup: FormGroup) {
  Object.keys(formGroup.controls).forEach(field => {
    const control = formGroup.get(field);
    if (control instanceof FormControl) {
      control.markAsTouched({ onlySelf: true });
    }
    else if (control instanceof FormGroup) {
      this.validateAllFormFields(control);
    }
  });
}


export function getMessageValidation(field: string, type:string){
  let response = null;
  switch(field){
    case 'name': {
      if(type == "required"){ response = "El nombre es necesario"; }
      else if (type == "minlength"){ response = "El nombre debe contener por lo menos 2 caracteres" }
      else if (type == "maxlength"){ response = "Este campo no puede contener más 30 caracteres" }
    } break;
    case 'lastname': {
      if(type == "required"){ response = "El apellido es necesario"; }
      else if (type == "minlength"){ response = "El apellido debe contener por lo menos 2 caracteres" }
      else if (type == "maxlength"){ response = "Este campo no puede contener más 30 caracteres" }
    } break;
    case 'birthday': {
      if(type == "required"){ response = "La fecha de nacimiento es necesaria"; }
      else if (type == "ngbDate"){ response = "Ingrese una fecha válida"; }
    } break;
    case 'gender': {
      if(type == "required"){ response = "El género es necesario"; }
    } break;
    case 'email': {
      if(type == "required"){ response = "El email es necesario"; }
      else if (type == "email"){ response = "Escriba un email correcto" }
      else if (type == "maxlength"){ response = "Este campo no puede contener más 40 caracteres" }
    } break;
    case 'password': {
      if(type == "required"){ response = "La contraseña es necesaria"; }
      else if (type == "minlength"){ response = "La contraseña debe contener por lo menos 8 caracteres" }
      else if (type == "maxlength"){ response = "Este campo no puede contener más 30 caracteres" }
    } break;
    case 'agree': {
      if(type == "required"){ response = "Debe aceptar los términos y condiciones para poder continuar"; }
    } break;
  }
  return response;
}