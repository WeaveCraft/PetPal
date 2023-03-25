import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Animal } from '../_models/animal';

@Injectable({
  providedIn: 'root'
})
export class AnimalsService {
  baseUrl = environment.apiUrl;
  animals: Animal[] = [];

  constructor(private http: HttpClient) { }

  getAnimals() {
    if(this.animals.length > 0) return of(this.animals);
    return this.http.get<Animal[]>(this.baseUrl + 'animals').pipe(
      map(animals => {
        this.animals = animals;
        return animals;
      })
    );
  }

  getAnimal(animalName: string) {
    const animal = this.animals.find(x => x.name === animalName);
    if(animal) return of(animal);
    return this.http.get<Animal>(this.baseUrl + 'animals/' + animalName);
  }
}
