import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Animal } from '../_models/animal';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers() {
    return this.http.get<Animal[]>(this.baseUrl + 'animals', this.getHttpOptions());
  }

  getMember(name: string) {
    return this.http.get<Animal>(this.baseUrl + 'animals/' + name, this.getHttpOptions());
  }

  getHttpOptions() {
    const userString = localStorage.getItem('animal');
    if (!userString) return;
    const user = JSON.parse(userString);
    return {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + user.token
      })
    }
  }
}
