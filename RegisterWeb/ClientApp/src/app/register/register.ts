import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class RegisterComponent {

  formData = {
    firstName: '',
    lastName: '',
    email: '',
    phone: '',
    birthDate: '',
    occupationId: 0,
    sex: '',
    profile: ''
  };

  constructor(private http: HttpClient) {
  }

  onSubmit() {
    console.log('Register clicked');

    this.http.post<{ id: number }>(
      '/api/register',
      this.formData
    ).subscribe({
      next: (response) => {
        alert('Registration successful!\nID: ' + response.id);
      },
      error: (error) => {
        console.error(error);
        alert('Registration failed.');
      }
    });
  }
}
