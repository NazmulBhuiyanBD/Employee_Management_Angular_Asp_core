import { Component, ElementRef, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { EmployeeService } from '../../services/employee';
import { EmployeeApiResponse, EmployeeListModel } from '../../models/Login.Model';

@Component({
  selector: 'app-employee',
  imports: [],
  templateUrl: './employee.html',
  styleUrl: './employee.css'
})
export class Employee implements OnInit {
employeeservices=inject(EmployeeService);
employeeList:EmployeeListModel[]=[];
showModal = false; 

@ViewChild("newModal") newModal!:ElementRef

ngOnInit(): void {
  this.getEmployeelist();
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

}
