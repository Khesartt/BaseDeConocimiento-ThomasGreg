import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { HomeComponent } from './home.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', component: HomeComponent },
           
            {
                path: 'galeriaTV',
                loadChildren: () => import('./gallery-tv/ProductAplicationComponent/gallery-tv.module').then(m => m.GalleryTVModule)
            },
            
            {
                path: 'galeriaGD',
                loadChildren: () => import('../home/gallery-gd/gallery-gd.module').then(m => m.GalleryGDModule)
            },
            {
                path: 'galeriaPT',
                loadChildren: () => import('../home/gallery-pt/gallery-pt.module').then(m => m.GalleryPTModule)
            }
        ]

    },


];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule { }
