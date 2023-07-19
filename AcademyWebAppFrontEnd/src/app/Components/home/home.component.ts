import { Component,OnInit } from '@angular/core';
import jwt_decode from 'jwt-decode';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  tokenData:any
  token:any;
  UserDashboardName:any;

  ngOnInit(): void {
    this.token=localStorage.getItem("token");
    this.tokenData= jwt_decode(this.token);
    this.UserDashboardName= this.tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
  }



}
