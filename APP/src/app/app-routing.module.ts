import { NgModule } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { ServicePersonnemetierComponent } from './service-personnemetier/service-personnemetier.component';
import { RecommandationComponent } from './recommandation/recommandation.component';
import { CategoriesComponent } from './categories/categories.component';

const routes: Routes = [
  {
    path:'login-register', component:LoginRegisterComponent
    },
  {
  path:'', component:HomeComponent
  },
  {
  path:'service-personnedemetiers', component:ServicePersonnemetierComponent
  },
  {
    path:'recommandations', component:RecommandationComponent
    },
    {
      path:'cat', component:CategoriesComponent
    }
];
@NgModule({
  imports: [RouterModule.forRoot(routes), MDBBootstrapModule ,   MDBBootstrapModule.forRoot()],
  exports: [RouterModule]
})
export class AppRoutingModule { }
