import { NgModule } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { RecommandationComponent } from './recommandation/recommandation.component';
import { CategoriesComponent } from './categories/categories.component';
import { ServiceComponent } from './service/service.component';
import { PersonneComponent } from './personne/personne.component';
import { AllrecommandationComponent } from './allrecommandation/allrecommandation.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'login-register', component: LoginRegisterComponent
  },
  {
    path: 'personne', component: PersonneComponent
  },
  {
    path: 'recommandations', component: RecommandationComponent
  },
  {
    path: 'cat', component: CategoriesComponent
  },
  {
    path: 'service', component: ServiceComponent
  },
  {
    path: 'AllRecommandation', component: AllrecommandationComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes), MDBBootstrapModule, MDBBootstrapModule.forRoot()],
  exports: [RouterModule]
})
export class AppRoutingModule { }
