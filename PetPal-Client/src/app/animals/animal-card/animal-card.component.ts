import { Component, OnInit, Input } from '@angular/core';
import { Animal } from 'src/app/_models/animal';

@Component({
  selector: 'app-animal-card',
  templateUrl: './animal-card.component.html',
  styleUrls: ['./animal-card.component.css']
})
export class AnimalCardComponent implements OnInit {
  @Input() animal: Animal | undefined;
  
  constructor() { }

  ngOnInit(): void {
  }

}
