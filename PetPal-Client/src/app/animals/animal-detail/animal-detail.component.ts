import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Animal } from 'src/app/_models/animal';
import { AnimalsService } from 'src/app/_services/animals.service';

@Component({
  selector: 'app-animal-detail',
  templateUrl: './animal-detail.component.html',
  styleUrls: ['./animal-detail.component.css']
})
export class AnimalDetailComponent implements OnInit {
  animal: Animal | undefined;

  constructor(private animalService: AnimalsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadAnimal();
  }

  loadAnimal() {
    const name = this.route.snapshot.paramMap.get('name');

    if(!name) return;

    this.animalService.getAnimal(name).subscribe({
      next: animal => this.animal = animal
    })
  }

}
