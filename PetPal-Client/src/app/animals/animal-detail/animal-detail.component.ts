import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery/public-api';
import { Animal } from 'src/app/_models/animal';
import { AnimalsService } from 'src/app/_services/animals.service';

@Component({
  selector: 'app-animal-detail',
  templateUrl: './animal-detail.component.html',
  styleUrls: ['./animal-detail.component.css']
})
export class AnimalDetailComponent implements OnInit {
  animal: Animal | undefined;
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];

  constructor(private animalService: AnimalsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadAnimal();

    this.galleryOptions = [
      {
        width: '31rem',
        height: '31rem',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
  }

  loadAnimal() {
    const name = this.route.snapshot.paramMap.get('name');

    if(!name) return;

    this.animalService.getAnimal(name).subscribe({
      next: animal => this.animal = animal
    })
  }

}
