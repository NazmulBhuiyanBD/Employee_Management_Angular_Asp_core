import { Component, ElementRef, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { EmployeeService } from '../../services/employee';
import { EmployeeApiResponse, EmployeeListModel, EmployeeModel } from '../../models/Login.Model';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee',
  imports: [FormsModule],
  templateUrl: './employee.html',
  styleUrl: './employee.css'
})
export class Employee implements OnInit {
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
