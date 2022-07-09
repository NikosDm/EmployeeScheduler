import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { TimeagoModule } from 'ngx-timeago';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { SkillListComponent } from './skills/skill-list/skill-list.component';
import { SkillDetailsComponent } from './skills/skill-details/skill-details.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { DateInputComponent } from './common/date-input/date-input.component';
import { TextInputComponent } from './common/text-input/text-input.component';
import { SelectInputComponent } from './common/select-input/select-input.component';
import { TextAreaComponent } from './common/text-area/text-area.component';
import { ConfirmModalComponent } from './modals/confirm-modal/confirm-modal.component';
import { ModalSkillComponent } from './modals/modal-skill/modal-skill.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    EmployeeListComponent,
    EmployeeDetailComponent,
    SkillListComponent,
    SkillDetailsComponent,
    NotFoundComponent,
    DateInputComponent,
    TextInputComponent,
    SelectInputComponent,
    TextAreaComponent,
    ConfirmModalComponent,
    ModalSkillComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    ButtonsModule.forRoot(),
    TimeagoModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
