import { AfterContentInit, Component, Input, OnInit} from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/filter';
import { IUserStatus, MyFundiService } from '../services/myFundiService';
import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, AfterContentInit{
  public title = 'app';
   presentLearnMore: boolean;
   actUserStatus: IUserStatus;

  constructor(private router: Router) {
    router.events
      .filter(event => event instanceof NavigationEnd)
      .subscribe((event: NavigationEnd) => {
        // You only receive NavigationEnd events
        this.presentLearnMore = this.isPresentLearnMore(event.url);
      });

  }
  ngOnInit() {
    window.addEventListener('resize', this.adaptResizeWindowsMenus, true);

    this.actUserStatus = MyFundiService.actUserStatus;

    $('input#mobilemenu').click(function () {
      document.getElementById('mainmenucontent').scrollIntoView({
        behavior: "smooth"
      });
    });

    $('#mainmenucontent').click(function () {
      document.getElementById('mainbodycontent').scrollIntoView({
        behavior: "smooth"
      });
    });
  }
  ngAfterContentInit() {
    window.addEventListener('resize', this.adaptResizeWindowsMenus, true);
  }
  adaptResizeWindowsMenus() {
    if (window.matchMedia("(max-width: 769px)").matches) {
      // The viewport is less than 768 pixels wide
      //alert("This is a mobile device.");
      $('input#mobilemenu').css('display', 'block !important');
    } else {
      // The viewport is at least 768 pixels wide
      //alert("This is a tablet or desktop.");=
      $('input#mobilemenu').css('display', 'none');
    }
  }
  private isPresentLearnMore(url:string): boolean {
    this.presentLearnMore = false;
    if (url.toLowerCase().indexOf('/login') > -1 ||
      url.toLowerCase().indexOf('/register') > -1 ||
      url.toLowerCase().indexOf('/forgot-password') > -1) {
      return false;
    }
    else { return true;}
  }
}
