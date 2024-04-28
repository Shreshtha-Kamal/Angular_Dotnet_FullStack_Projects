import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const adminAuthGuard: CanActivateFn = (route, state) => {
  let _router=inject(Router);
  if(localStorage.getItem('isAdminLoggedin')=='true'){
    return true;
  }
  else{
    alert('Login with Admin Credential to access this route');
    _router.navigate(['']);
    return false;
  }
};
