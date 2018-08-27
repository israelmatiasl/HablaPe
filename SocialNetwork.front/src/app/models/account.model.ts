export class SessionReq {
    constructor(
        public email: string,
        public password:string,
        public remember:boolean
    ){ }
}

export class SessionRes {
    constructor(
        public name: string,
        public lastname: string,
        public nick:string,
        public birthday:Date,
        public gender:string,
        public photo:string,
        public token:string
    ){ }
}

export class Register {
    constructor(
        public name: string,
        public lastname:string,
        public gender:string,
        public birthday:DateFormat,
        public email:string,
        public password:string,
        public agree:boolean
    ){ }
}

export class RegisterReq {
    constructor(
        public name: string,
        public lastname:string,
        public gender:string,
        public birthday:string,
        public email:string,
        public password:string,
        public agree:boolean
    ){ }
}

export class RegisterRes {
    constructor(
        public message: string,
        public name: string
    ){ }
}

export class DateFormat {
    constructor(
        public day:number,
        public month:number,
        public year:number
    ) { }
}