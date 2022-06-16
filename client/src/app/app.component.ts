import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'YashobaTouchedThis';
  //Tpe script comes with type safety so you can turn it off any time you want with initializing the varable to any
  users: any;
   //Dependancy injection in angular is done by constructor injction in angular
   //When the API request is created this is naturally an asynchronous event
   //Fetching data in the constructor is possible but it's considered a bit too early  
   //so we can use angular life cycle event, instead 
   //Which do have onInit()   
   constructor(private http: HttpClient){}
  ngOnInit() {
    //this. keyword is needed to access any property inside the class so basically http is inside the class AppComponent
   this.getUsers();
    
  }
  getUsers(){
    //http get returns an observarable so when returning data this person is telling to always subscribe coz unless we subscribe, this lazy http get won't return what we need
    this.http.get('https://localhost:5001/api/users').subscribe(response=>{
      this.users = response;
    },error =>{
      console.log(error);
    }
    )
    //CORS refer to Cross Origin Resource sharing: blocked by CORS policy is al that the person doiing the course did get bt I wn't aparantly get that. 
    //he gets it as the ngular runs on port 4200 while .Net runs on port 5001 or 5000
    //Unless this is said to be OK, You'll always receive an error
    //so let's just add Cors to services in StartUp. 
  }

}
