import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountsService } from '../_services/accounts.service';
//Angular supports two way binding

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  //loggedIn: boolean;//a boolean's default value is false//we had it in the ngIf where now we have "currentUser$ | async"
  currentUser$: Observable<User>;
  constructor(public accountService: AccountsService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;

  }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(this.model);
      console.log(response);
      //this.loggedIn = true;
      this.router.navigateByUrl('/members');
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    //this.loggedIn = false;
  }
  // getCurrentUser(){//All the things we've done here could be done with currentUser$  
  //   this.accountService.currentUser$.subscribe(user=>{
  //     //this.loggedIn = !!user;
  //   },error =>{
  //     console.log(error);
  //   })
  // }
}
