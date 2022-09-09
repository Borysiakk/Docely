import { Component, OnInit } from '@angular/core';
import { faFolderBlank } from '@fortawesome/free-regular-svg-icons';
import { faCalendar } from '@fortawesome/free-regular-svg-icons';
import { faFileCirclePlus } from '@fortawesome/free-solid-svg-icons';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { faBriefcase } from '@fortawesome/free-solid-svg-icons';
import { faSkullCrossbones } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit
{
  faUser = faUser;
  faBriefcase = faBriefcase;
  faCalendar = faCalendar;
  faFolderBlank = faFolderBlank;
  faFileCirclePlus = faFileCirclePlus;
  faSkullCrossbones = faSkullCrossbones;
  constructor() { }

  ngOnInit(): void
  {
  }

}
