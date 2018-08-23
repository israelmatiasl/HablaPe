import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';

const appRoutes : Routes = [
    { path: 'auth', component: AuthComponent },
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, {useHash:true});