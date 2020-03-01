import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  @Input() esAdmin: string;

  constructor() {
    console.log({mene:this.esAdmin})
  }
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  salir() {
    this.esAdmin = 'N/A';
    localStorage.removeItem('usuario')
    window.location.reload();
  }
}
