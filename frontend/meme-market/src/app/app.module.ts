import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { OrderViewComponent } from './order-view/order-view.component';
import { PositionViewComponent } from './position-view/position-view.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { OrderFormComponent } from './order-form/order-form.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    OrderViewComponent,
    PositionViewComponent,
    OrderFormComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatInputModule,
    MatDialogModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', pathMatch: 'full', redirectTo: 'positions'},
      {path: 'orders', component: OrderViewComponent},
      {path: 'positions', component: PositionViewComponent},
    ]),
  
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    OrderFormComponent
  ]
})
export class AppModule { }
