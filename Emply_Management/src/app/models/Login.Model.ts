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