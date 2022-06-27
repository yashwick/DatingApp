import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountsService } from '../_services/accounts.service';

@Injectable({//We are not going to inject this to anywhere but will keep this as it is since it's auto generated
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private accountService: AccountsService, private toastr: ToastrService) {}

  canActivate(): Observable<boolean>{
    return this.accountService.currentUser$.pipe(
      map(user=>{
        if (user) return true;
        this.toastr.error("You shall not pass!")
      } )
    );
  }
  
}
