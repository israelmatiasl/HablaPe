export class SessionReq {
    constructor(
        public email: string,
        public password:string,
        public remember:boolean
    ){ }
}

export class SessionRes {
    constructor(
        public success:boolean,
        public name: string,
        public lastname: string,
        public nick:string,
        public birthday:Date,
        public gender:string,
        public photo:string,
        public token:string
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
        public success: boolean,
        public message: string,
        public name: string
    ){ }
}