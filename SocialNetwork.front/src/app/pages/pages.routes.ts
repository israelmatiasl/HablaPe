import { RouterModule, Routes } from "@angular/router";
import { PagesComponent } from './pages.component';

import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { MessagesComponent } from './messages/messages.component';
import { FriendsComponent } from './friends/friends.component';
import { WorldComponent } from './world/world.component';

//import { SessionGuard } from "../services/services.index";

const pagesRoutes : Routes = [
    {
        path: '',
        component: PagesComponent,
        children : [
            // { path: 'home', component: HomeComponent, data: { title: 'Home', showHeader: false }, canActivate: [SessionGuard] },
            { path: 'home', component: HomeComponent, data: { title: 'Inicio'} },
            { path: 'profile/:nick', component: ProfileComponent, data: { title: 'Perfil' } },
            { path: 'messages', component: MessagesComponent, data: { title: 'Mensajes' } },
            { path: 'friends', component: FriendsComponent, data: { title: 'Amigos' } },
            { path: 'world', component: WorldComponent, data: { title: 'Mundo' } },
            { path: '', pathMatch: 'full', redirectTo: 'home' }
        ]
    }
];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);