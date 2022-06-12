import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import { HomeComponent } from './user/home/home.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatMenuModule} from '@angular/material/menu';
import { NavbarComponent } from './user/navbar/navbar.component';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule} from '@angular/forms';
import { CategoriesComponent } from './user/categories/categories.component';
import { FooterComponent } from './user/footer/footer.component';
import { ServiceComponent } from './user/service/service.component';
import {MatStepperModule} from '@angular/material/stepper';
import { PersonneComponent } from './user/personne/personne.component';
import { AllrecommandationComponent } from './user/allrecommandation/allrecommandation.component';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import { SearchBarComponent } from './user/search-bar/search-bar.component';
import { LoginComponent } from './admin/login/login.component';
import { CategoriesadminComponent } from './admin/categoriesadmin/categoriesadmin.component';
import { NavbaradminComponent } from './admin/navbaradmin/navbaradmin.component';
import { ServiceadminComponent } from './admin/serviceadmin/serviceadmin.component';
import { PersonneadminComponent } from './admin/personneadmin/personneadmin.component';
import { RecommandationadminComponent } from './admin/recommandationadmin/recommandationadmin.component';
import { AddCatComponent } from './admin/categoriesadmin/add-cat/add-cat.component';
import { AddServiceComponent } from './admin/serviceadmin/add-service/add-service.component';
import { AddPersonneComponent } from './admin/personneadmin/add-personne/add-personne.component';
import { UpdatePersonneComponent } from './admin/personneadmin/update-personne/update-personne.component';
import { UpdateServiceComponent } from './admin/serviceadmin/update-service/update-service.component';
import { UpdateCatComponent } from './admin/categoriesadmin/update-cat/update-cat.component';
import { NonapprouverComponent } from './admin/recommandationadmin/nonapprouver/nonapprouver.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    CategoriesComponent,
    FooterComponent,
    ServiceComponent,
    PersonneComponent,
    AllrecommandationComponent,
    SearchBarComponent,
    LoginComponent,
    CategoriesadminComponent,
    NavbaradminComponent,
    ServiceadminComponent,
    PersonneadminComponent,
    RecommandationadminComponent,
    AddCatComponent,
    AddServiceComponent,
    AddPersonneComponent,
    UpdatePersonneComponent,
    UpdateServiceComponent,
    UpdateCatComponent,
    NonapprouverComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatTabsModule,
    MatMenuModule,
    MatSelectModule,
    MatGridListModule,
    HttpClientModule,
    FormsModule,
    MatStepperModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
