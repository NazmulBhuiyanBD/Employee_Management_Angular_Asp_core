import { Component, inject } from '@angular/core';
import { EmployeeService } from '../../services/employee';
import { EmployeeApiResponse, EmployeeListModel, EmployeeModel } from '../../models/Login.Model';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-leave',
  imports: [FormsModule],
  templateUrl: './leave.html',
  styleUrl: './leave.css'
})
export class Leave {
employeeservices=inject(EmployeeService);
employeeList:EmployeeListModel[]=[];
showModal = false; 

// @ViewChild("newModal") newModal!:ElementRef
deptList:Observable<any[]>=new Observable<any[]>;

employeeObj:EmployeeModel=new EmployeeModel();

ngOnInit(): void {
  this.getEmployeelist();
  this.deptList=this.employeeservices.getDept()
}
getEmployeelist()
{
  this.employeeservices.getEmployee().subscribe(
    {
      next:(result:EmployeeApiResponse)=>{
        this.employeeList=result.data;
      },
      error:(error)=>{

      }
    }

  )
}

saveEmployee()
{
  this.employeeservices.onSaveEmployee(this.employeeObj).subscribe(
    {
      next:(result:any)=>{
        if(result.result)
        {
          this.getEmployeelist()
          alert("Employee Created")
        }
        else{
          alert(result.message)
        }
      },
      error:(error)=>{

      }
    }

  )
}
}
