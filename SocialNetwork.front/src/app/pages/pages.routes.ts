import { RouterModule, Routes } from "@angular/router";
import { PagesComponent } from './pages.component';

import { HomeComponent } from './home/home.component';

//import { SessionGuard } from "../services/services.index";

const pagesRoutes : Routes = [
    {
        path: '',
        component: PagesComponent,
        children : [
            // { path: 'home', component: HomeComponent, data: { title: 'Home', showHeader: false }, canActivate: [SessionGuard] },
            // { path: 'profile', component: ProfileComponent, data: { title: 'Profile', showHeader: true }, canActivate: [SessionGuard] },
            { path: 'home', component: HomeComponent, data: { title: 'Home', showHeader: false } },
            { path: '', pathMatch: 'full', redirectTo: 'home' }
        ]
    }
];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);