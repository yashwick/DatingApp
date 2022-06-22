import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountsService } from '../_services/accounts.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  //@Input() usersFromHomeComponent: any;//To pass down values from parent to child we use this,home to register component,So just use square brackets in the html.. purpose of squae brackets is to pass data from parent to child
  @Output() cancelRegister = new EventEmitter();//To pass values from child to parent we use this,cancel was made//$event is used//4 things needs to be done 
  model: any = {};
  hidden = false;

  constructor(private accountServices: AccountsService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }
  register() {
    console.log(this.model);
    this.accountServices.register(this.model).subscribe(response => {
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }
  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false);//When the buton is clicked false will be emitted
  }
}
