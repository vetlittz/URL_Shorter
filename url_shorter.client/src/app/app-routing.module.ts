import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UrlInfoComponent } from './url-info/url-info.component';
import { UrlTableComponent } from './url-table/url-table.component';
import { RegisterComponent } from './register/register.component';
import { DescriptionComponent} from './description/description.component'

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'url-info', component: UrlInfoComponent },
  { path: 'url-table', component: UrlTableComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'description', component: DescriptionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
