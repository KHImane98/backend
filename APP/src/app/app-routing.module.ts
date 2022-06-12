import { NgModule } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './user/home/home.component';
import { CategoriesComponent } from './user/categories/categories.component';
import { ServiceComponent } from './user/service/service.component';
import { PersonneComponent } from './user/personne/personne.component';
import { AllrecommandationComponent } from './user/allrecommandation/allrecommandation.component';
import { LoginComponent } from './admin/login/login.component';
import { CategoriesadminComponent } from './admin/categoriesadmin/categoriesadmin.component';
import { PersonneadminComponent } from './admin/personneadmin/personneadmin.component';
import { ServiceadminComponent } from './admin/serviceadmin/serviceadmin.component';
import { RecommandationadminComponent } from './admin/recommandationadmin/recommandationadmin.component';
import { AddCatComponent } from './admin/categoriesadmin/add-cat/add-cat.component';
import { NonapprouverComponent } from './admin/recommandationadmin/nonapprouver/nonapprouver.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'personne', component: PersonneComponent
  },
  {
    path: 'non-approuver', component: NonapprouverComponent
  },
  {
    path: 'service', component: ServiceComponent
  },
  {
    path: 'AllRecommandation', component: AllrecommandationComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'add-cat', component:CategoriesadminComponent
  },
  {
    path: 'add-personne', component:PersonneadminComponent
  },
  {
    path: 'add-service', component:ServiceadminComponent
  },
  {
    path: 'rec-admin', component: RecommandationadminComponent
  },
  {
    path: 'add1-cat', component: AddCatComponent
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes), MDBBootstrapModule, MDBBootstrapModule.forRoot()],
  exports: [RouterModule]
})
export class AppRoutingModule { }
