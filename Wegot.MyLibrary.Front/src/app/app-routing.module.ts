import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './components/book/create/create.component';
import { DetailsComponent } from './components/book/details/details.component';
import { ListComponent } from './components/book/list/list.component';

const routes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'books', component: ListComponent },
  { path: 'book/:id', component: DetailsComponent },
  { path: 'add', component: CreateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }