import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { LoginComponent } from './page/login/login.component';
import { MainComponent } from './page/main/main.component';
import { RegisterComponent } from './page/register/register.component';

const routes: Routes = [
  {path:"",component:LoginComponent},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"main",component:MainComponent, canActivate:[AuthGuard]}//kad neprisijungus ,neleis pasiekti main puslapio
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
