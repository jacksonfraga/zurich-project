import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SeguroReportComponent } from './seguro-report/seguro-report.component';

@NgModule({
  declarations: [
    AppComponent,
    SeguroReportComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
