export class LoginModel{
    emailId: string;
    password: string;

    constructor() {
        this.emailId='';
        this.password='';        
    }
}
export interface EmployeeApiResponse{
      message: string;
  result: boolean;
  data:any;
}

export interface EmployeeListModel{
    employeeId: number,
      employeeName: string,
      deptId: number,
      deptName: string,
      contactNo: number,
      emailId: string,
      role: string
}
export class EmployeeModel{
    employeeId: number
      employeeName: string
      deptId: number
      contactNo: string
      emailId: string
      password:string
      gender:string
      role: string

      constructor() {
        this.employeeId=0,
        this.deptId=0;
        this.contactNo='';
        this.emailId='';
        this.employeeName='';
        this.gender='';
        this.password='';
        this.role='';
      }
      
}