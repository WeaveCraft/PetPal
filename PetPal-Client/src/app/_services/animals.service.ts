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
    return this.http.get<Animal[]>(this.baseUrl + 'animals');
  }

  getAnimal(name: string) {
    return this.http.get<Animal>(this.baseUrl + 'animals/' + name);
  }
}
