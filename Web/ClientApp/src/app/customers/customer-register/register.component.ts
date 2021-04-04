import { Component, OnInit } from '@angular/core';
import { FormBuilder,
  FormGroup,
  Validators,
  FormControl, 
  FormArray} from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService:AuthService,
    private formBuilder:FormBuilder) { }

    registerForm : FormGroup;
    registerUser:any={}
  ngOnInit() {
    this.createRegisterForm()
  }

  createRegisterForm(){
    this.registerForm = this.formBuilder.group(
      {
        UserName:["",Validators.required],
        Password:["",[Validators.required,
        Validators.minLength(4)]],
        ConfirmPassword:["",Validators.required],
        TCno : ["",Validators.required],
        Name : ["",Validators.required],
        Surname : ["",Validators.required],
        Email : ["",[Validators.required, Validators.email]],
        PhoneNumber : ["",Validators.required],
        Address : ["",Validators.required]
      },
      {validator:this.passwordMatchValidator}
    )
  }

   passwordMatchValidator(g:FormGroup){
     return g.get('Password').value === 
     g.get('ConfirmPassword').value?null:{mismatch:true}
   }

   registerCustomer(){
     if(this.registerForm.valid){
       this.registerUser = Object.assign({},this.registerForm.value)
       this.authService.registerCustomer(this.registerUser)
     }
   }
}
