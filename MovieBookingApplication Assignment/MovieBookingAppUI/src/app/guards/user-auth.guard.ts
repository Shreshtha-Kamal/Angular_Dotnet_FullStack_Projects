import { inject } from "@angular/core";
import { CanActivateFn, Router } from '@angular/router';

export const userAuthGuard: CanActivateFn = (route, state) => {
  let _router= inject(Router);
  if(localStorage.getItem('isUserLoggedIn')=='true'){
    return true;
  }
  else{
    alert('You Need to Login First to Access this Page');
    _router.navigate(['']);
    return false;
  }
};
