import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Animal } from 'src/app/_models/animal';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AnimalsService } from 'src/app/_services/animals.service';

@Component({
  selector: 'app-animal-edit',
  templateUrl: './animal-edit.component.html',
  styleUrls: ['./animal-edit.component.css']
})
export class AnimalEditComponent implements OnInit {
  animal: Animal | undefined;
  user: User | null = null;

  constructor(private accountService: AccountService, private animalService: AnimalsService) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.user = user
    })
  }

  ngOnInit(): void {
    this.loadAnimal();
  }

  loadAnimal() {
    if(!this.user) return;
    this.animalService.getAnimal(this.user.username).subscribe({
      next: animal => this.animal = animal
  })
}

}
