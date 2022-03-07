import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NgZone } from '@angular/core'; 
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ActiveCrudOperationsComponent } from './activecrudoperations/activecrudoperations.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddLocationComponent } from './addLocation/addLocation.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgotPassword/forgotPassword.component';
import { UserRolesComponent } from './userroles/userroles.component';
import { ContactUsComponent } from './contactus/contactus.component';
import { AboutUsComponent } from './about/aboutus.component';
import { SectionsContactComponent } from './sectionscontact/sectionscontact.component';
import { PayPalSuccessComponent } from './paypalSuccess/paypal-success.component';
import { PayPalFailureComponent } from './paypalFailure/paypal-failure.component';
import { NewRolesComponent } from './newroles/newroles.component';
import { APP_BASE_HREF } from '@angular/common';
import { MyFundiService } from '../services/myFundiService';
import { AppInterceptor } from '../interceptors/app.interceptor';
import { QrCodeComponent } from './qrCodeReader/qrCodeReader.component';
import { AddressComponent } from './crud-operations/address/address.component';
import { CompanyComponent } from './crud-operations/company/company.component';
import { LocationComponent } from './crud-operations/location/location.component';
import { SuccessComponent } from './success/success.component';
import { FailureComponent } from './failure/failure.component';

import { AdministratorRoleComponent } from './roles/administrator/administrator.component';
import { GuestRoleComponent } from './roles/guest/guest.component';
import { FundiRoleComponent } from './roles/fundi/fundi.component';
import { AuthGuard } from '../guards/AuthGuard';
import { AdminAuthGuard } from '../guards/AdminAuthGuard';
import { TwitterProfileFeedsComponent } from '../socialmedia/twitterfeeds/twitterprofilefeeds.component';
import { ClientRoleComponent } from './roles/client/client.component';
import { AuthFundiGuard } from '../guards/AuthFundiGuard';
import { AuthClientGuard } from '../guards/AuthClientGuard';
import { ProfileComponent } from './profile/profile.component';
import { CoursesComponent } from './crud-operations/courses/courses.component';
import { CertificationComponent } from './crud-operations/certification/certification.component';
import { WorkCategoryComponent } from './crud-operations/work-category/workcategory.component';
import { ProfileCreateComponent } from './profile-create/profilecreate.component';
import { CourseCrudComponent } from './crud-operations/coursescrud/coursescrud.component';
import { CertificationCrudComponent } from './crud-operations/certificationcrud/certificationcrud.component';
import { WorkCategoryCrudComponent } from './crud-operations/workcategorycrud/workcategorycrud.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ActiveCrudOperationsComponent,
    FetchDataComponent,
    LocationComponent,
    AddLocationComponent,
    LoginComponent,
    ForgotPasswordComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    UserRolesComponent,
    ContactUsComponent,
    AboutUsComponent,
    SectionsContactComponent,
    PayPalSuccessComponent,
    PayPalFailureComponent,
    NewRolesComponent,
    QrCodeComponent,
    AddressComponent,
    LocationComponent,
    CompanyComponent,
    SuccessComponent,
    FailureComponent,
    AdministratorRoleComponent,
    GuestRoleComponent,
    FundiRoleComponent,
    ClientRoleComponent,
    TwitterProfileFeedsComponent,
    ProfileComponent,
    ProfileCreateComponent,
    CoursesComponent,
    CertificationComponent,
    WorkCategoryComponent,
    CourseCrudComponent,
    CertificationCrudComponent,
    WorkCategoryCrudComponent


  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'crud', component: ActiveCrudOperationsComponent, canActivate:[AuthGuard] },
      { path: 'manage-profile', component: ProfileComponent, canActivate: [AuthGuard] },
      { path: 'create-profile', component: ProfileCreateComponent, canActivate: [AuthFundiGuard] },
      { path: 'add-location', component: LocationComponent, canActivate: [AdminAuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'scanqrcode', component: QrCodeComponent, canActivate:[AuthGuard] },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'logout', component: HomeComponent },
      { path: 'manage-roles', component: UserRolesComponent, canActivate: [AdminAuthGuard]},
      { path: 'contactus', component: ContactUsComponent },
      { path: 'aboutus', component: AboutUsComponent },
      { path: 'paypal-success', component: PayPalSuccessComponent },
      { path: 'paypal-failure', component: PayPalFailureComponent },
      { path: 'success', component: SuccessComponent },
      { path: 'failure', component: FailureComponent }, 
      { path: 'Administrator', component: AdministratorRoleComponent, canActivate: [AdminAuthGuard] },
      { path: 'Guest', component: GuestRoleComponent, canActivate: [AuthGuard] },
      { path: 'Fundi', component: FundiRoleComponent, canActivate: [AuthFundiGuard] },
      { path: 'Client', component: ClientRoleComponent, canActivate: [AuthClientGuard] }
    ])
  ],
  providers: [{ provide: AdminAuthGuard, useClass: AdminAuthGuard },
    { provide: AuthFundiGuard, useClass: AuthFundiGuard },
    { provide: AuthClientGuard, useClass: AuthClientGuard },
    { provide: AuthGuard, useClass: AuthGuard },
    { provide: HttpClient, useClass: HttpClient },
    { provide: MyFundiService, useClass: MyFundiService },
    { provide: HTTP_INTERCEPTORS,useClass: AppInterceptor, multi: true},
    { provide: APP_BASE_HREF, useValue: '/myFundi/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
