import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { Message } from 'src/app/_models/message';
import { MembersService } from 'src/app/_services/members.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member = {} as Member;
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];
  messages: Message[] = [];

  constructor(private memberService: MembersService, private route: ActivatedRoute, private toastr: ToastrService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.route.data.subscribe({
      next: data => this.member = data['member']
    })

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
    this.galleryImages = this.getImages();
    this.loadMessages();
  }

  addLike(member: Member) {
    this.memberService.addLike(member.username).subscribe({
      next: () => this.toastr.success('You liked ' + member.username)
    })
  }
  
  getImages() {
    if (!this.member) return [];
    const imageUrls = [];
    for(const photo of this.member.photos) {
      imageUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url
      })
    }
    console.log(imageUrls, " imageurls");
    return imageUrls;
  }
  
  loadMessages() {
    if (this.member) {
      this.messageService.getMessageThread(this.member.username).subscribe({
        next: messages => this.messages = messages
      })
    }
  }

  capitalizeFirstLetter(str: string): string {
    if (!str) return '';
    return str.charAt(0).toUpperCase() + str.slice(1);
  }
  
}


