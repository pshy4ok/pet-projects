import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { TokenService } from "./token.service";

@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  constructor(private tokenService: TokenService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.tokenService.isTokenValid()) {
      return true;
    } else {
      console.error('Token expired or not available. Redirecting to login page.');
      this.router.navigate(['/login']);
      return false;
    }
  }
}
