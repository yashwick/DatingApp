import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
 //users: any;//to pass these sers to register compnent which is a child of home component,we need to have @Input decorater in the chld(register)
  constructor() { }

  ngOnInit(): void {
    //this.getUsers();
  }
  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  // getUsers() {
  //   this.http.get('https://localhost:5001/api/users').subscribe(users => this.users = users)//setting up parent to child(home to register)
  // }
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
