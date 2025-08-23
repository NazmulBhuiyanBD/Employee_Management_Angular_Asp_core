import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginModel } from '../../models/Login.Model';
import { EmployeeService } from '../../services/employee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
loginObj:LoginModel=new LoginModel();
employeeService=inject(EmployeeService)
router=inject(Router)
onLogin()
{
this.employeeService.onLogin(this.loginObj).subscribe({
  next:(rest:any)=>{
    if(rest.result)
    {
      alert("login success")
      localStorage.setItem("loginInfo",JSON.stringify(rest.data))
      this.router.navigateByUrl("/dashboard")
    }
    else{
      alert(rest.message+"invalid Information")
    }
  },
  error:()=>{
    alert("api error")
  }
})
}

}
