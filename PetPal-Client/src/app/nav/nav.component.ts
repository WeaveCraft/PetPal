import { Component, OnInit } from '@angular/core';
import { Router, UrlSerializer } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  registerMode = false;
  users: any;

  constructor(public accountService: AccountService, private routers: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    const navbarToggler = document.querySelector('.navbar-toggler');
    const navbarCollapse = document.querySelector('.navbar-collapse');
    
    navbarToggler?.addEventListener('click', () => {
      navbarCollapse?.classList.toggle('show');
    });
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: () => 
        this.routers.navigateByUrl('/members'),
    })
  }

  logout() {
    this.accountService.logout();
    this.routers.navigateByUrl('/');
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  

}
