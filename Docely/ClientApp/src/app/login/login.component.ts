import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { environment } from '../../environments/environment';


interface UserResult{
  name: string;
  surName: string;
  email: string;
  password: string;
}

interface LoginResult {
  user: UserResult;
  token: string;
  refreshToken: string;
  authDate: Date;
  succeeded: boolean;
  statusCode: number;
  errors: string[];
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
    public http: HttpClient
  ) {
    this.loginForm = this.formBuilder.group({
      email: [''],
      password: ['']
    });
  }

  login() {
    const postData = {
      login: 'BORYSIAK',
      password: 'string'
    };

    this.http.post<LoginResult>(environment.apiUrl + '/Authenticate/Login', postData).subscribe(
      (data: LoginResult) => {
        console.log(data);
      }
    );
  }
  ngOnInit(): void {
  }

}
