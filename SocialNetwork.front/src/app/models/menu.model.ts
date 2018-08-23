export class MenuLeft {
    constructor(
        public name: string,
        public icon: string,
        public path: string
    ){ }
}

export class MenuTop {
    constructor(
        public name: string,
        public path: string
    ){ }
}

export class MenuResponse {
    constructor(
        public menuLeft: MenuLeft[],
        public menuTop: MenuTop[]
    ){ }
}