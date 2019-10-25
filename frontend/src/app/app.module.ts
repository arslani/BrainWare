import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyOrdersComponent } from './company-orders/company-orders.component';
import { ApiClientService } from './services/api-client.service';
import { HttpClientModule } from '@angular/common/http';
import { ChangesComponent } from './changes/changes.component';

@NgModule({
  declarations: [
    AppComponent,
    CompanyOrdersComponent,
    ChangesComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [ApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
