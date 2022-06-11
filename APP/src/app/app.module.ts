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
import { HomeComponent } from './home/home.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatMenuModule} from '@angular/material/menu';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { NavbarComponent } from './home/navbar/navbar.component';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import { RecommandationComponent } from './recommandation/recommandation.component';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule} from '@angular/forms';
import { CategoriesComponent } from './categories/categories.component';
import { FooterComponent } from './footer/footer.component';
import { ServiceComponent } from './service/service.component';
import {MatStepperModule} from '@angular/material/stepper';
import { PersonneComponent } from './personne/personne.component';
import { AllrecommandationComponent } from './allrecommandation/allrecommandation.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginRegisterComponent,
    NavbarComponent,
    RecommandationComponent,
    CategoriesComponent,
    FooterComponent,
    ServiceComponent,
    PersonneComponent,
    AllrecommandationComponent    
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
    MatStepperModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
