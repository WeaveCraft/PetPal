import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Animal } from '../_models/animal';

@Injectable({
  providedIn: 'root'
})
export class AnimalsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAnimals() {
    return this.http.get<Animal[]>(this.baseUrl + 'animals', this.getHttpOptions());
  }

  getAnimal(name: string) {
    return this.http.get<Animal>(this.baseUrl + 'animals/' + name, this.getHttpOptions());
  }

  getHttpOptions() {
    const animalString = localStorage.getItem('animal');
    if (!animalString) return;
    const user = JSON.parse(animalString);
    return {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + user.token
      })
    }
  }
}
