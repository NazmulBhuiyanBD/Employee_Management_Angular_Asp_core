import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeApiResponse } from '../models/Login.Model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private http:HttpClient){}
  onLogin(obj:any)
  {
    return this.http.post("https://freeapi.miniprojectideas.com/api/EmployeeLeave/Login",obj)
  }

  getEmployee():Observable<EmployeeApiResponse>
  {
    return this.http.get<EmployeeApiResponse>("https://freeapi.miniprojectideas.com/api/EmployeeLeave/GetEmployees")
  }

  
}
