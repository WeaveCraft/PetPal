import { Component, Input, Self, ViewChild } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl, NgForm } from '@angular/forms';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent implements ControlValueAccessor {
  @Input() label = '';
  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }

}