export class BodyResponse {
    constructor(
        public success:boolean,
        public message:string
    ){ }
}

export class Alert {
    constructor(
        public owner:string,
        public show:boolean,
        public type:string,
        public message:string,
        public duration:number
    ) { }
}

export class AlertBody {
    constructor(
        public show:boolean,
        public type:string,
        public message:string 
    ){ }
}