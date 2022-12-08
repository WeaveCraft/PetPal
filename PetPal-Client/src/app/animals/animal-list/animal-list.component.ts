import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/app/_models/animal';
import { AnimalsService } from 'src/app/_services/animals.service';

@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.css']
})
export class AnimalListComponent implements OnInit {
  animals: Animal[] = [];

  constructor(private animalService: AnimalsService) { }

  ngOnInit(): void {
    this.loadAnimals();
  }

  loadAnimals() {
    this.animalService.getAnimals().subscribe({
      next: animals => this.animals = animals
    })
  }

}
