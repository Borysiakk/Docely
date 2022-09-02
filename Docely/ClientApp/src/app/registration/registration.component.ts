import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { environment } from '../../environments/environment';

interface RegisterResult {
  Succeded: boolean,
  Errors: string[]
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  public registerForm: FormGroup;
  public errors: string[] = [];

  constructor(
    public formBuilder: FormBuilder,
    public http: HttpClient
  ) {
    this.registerForm = this.formBuilder.group({
      name: [''],
      surName: [''],
      email: [''],
      password: [''],
      passwordTwo: ['']
    });
  }

  ngOnInit(): void {
  }

  register() {
    if(this.registerForm.controls.password.value !== this.registerForm.controls.passwordTwo.value) {
      this.errors = [ "Passwords do not match" ];
      return;
    }

    // check if email is proper email
    if(!/^\S+@\S+\.\S+$/.test(this.registerForm.controls.email.value)) {
      this.errors = [ "This is not proper email you fucking idiot" ];
      return;
    }

    const postData = {
      name: this.registerForm.controls.name.value,
      surName: this.registerForm.controls.surName.value,
      email: this.registerForm.controls.email.value,
      password: this.registerForm.controls.password.value
    };

    return this.http.post<RegisterResult>(environment.apiUrl + '/Authenticate/Register', postData).subscribe(
      (data: RegisterResult) => {
        alert("Registration succeeded");
      }, (response: any) => {
        this.errors = response.error.errors;
      });
  }

}
