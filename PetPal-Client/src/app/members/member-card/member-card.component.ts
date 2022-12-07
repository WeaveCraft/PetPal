import { Component, Input, OnInit } from '@angular/core';
import { Animal } from 'src/app/_models/animal';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member | undefined;
  @Input() animal: Animal | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
