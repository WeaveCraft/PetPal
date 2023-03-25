import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from 'src/app/_models/animal';
import { AnimalsService } from 'src/app/_services/animals.service';

@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.css']
})
export class AnimalListComponent implements OnInit {
  animals$: Observable<Animal[]> | undefined;

  constructor(private animalService: AnimalsService) { }

  ngOnInit(): void {
    this.animals$ = this.animalService.getAnimals();
  }
}
