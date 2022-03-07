import { Component, OnInit, Injectable, Inject, AfterContentInit } from '@angular/core';
import { IAddress, ILocation, MyFundiService } from '../../../services/myFundiService';
import * as $ from 'jquery';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Component({
    selector: 'location',
    templateUrl: './location.component.html',
    styleUrls: ['./location.component.css'],
    providers: [MyFundiService]
})
@Injectable()
export class LocationComponent implements OnInit, AfterContentInit {
  private myFundiService: MyFundiService ;
  public constructor(myFundiService: MyFundiService , private router: Router) {
    this.myFundiService = myFundiService;
    }
    public location: ILocation | any;

  public addLocation(): void {
    this.location.address = null;
      let actualResult: Observable<any> = this.myFundiService.PostOrCreateLocation(this.location);
      actualResult.map((p: any) => {
        alert('Location Added: ' + p.result); if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
    }
    public updateLocation() {
      let actualResult: Observable<any> = this.myFundiService.UpdateLocation(this.location);
      actualResult.map((p: any) => {
        alert('Location Updated: ' + p.result); if (p.result) {
          this.router.navigateByUrl('success');
        }
        else {
          this.router.navigateByUrl('failure');
        }
        }).subscribe();
        $('form#locationView').css('display', 'block').slideDown();
  }
  public selectLocation(): void {
    let actualResult: Observable<any> = this.myFundiService.GetLocationById(this.location.locationId);
    actualResult.map((p: any) => {
      this.location = p; 
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
  public deleteLocation() {
    let actualResult: Observable<any> = this.myFundiService.DeleteLocation(this.location);
    actualResult.map((p: any) => {
      alert('Location Deleted: ' + p.result); if (p.result) {
        this.router.navigateByUrl('success');
      }
      else {
        this.router.navigateByUrl('failure');
      }
    }).subscribe();
    $('form#locationView').css('display', 'block').slideDown();
  }
    public ngOnInit(): void {
        this.location = {}
        this.location.address = {};
  }
  ngAfterContentInit(): void {
    const addsObs: Observable<IAddress[]> = this.myFundiService.GetAllAddresses();
    const locatObs: Observable<ILocation[]> = this.myFundiService.GetAllLocations();

    let optionElem: HTMLOptionElement = document.createElement('option');
    optionElem.selected = true;
    optionElem.value = (0).toString();
    optionElem.text = "Select Location";
    document.querySelector('select#locationId').append(optionElem);

    optionElem = document.createElement('option');
    optionElem.value = (0).toString();
    optionElem.text = "Select Address";
    document.querySelector('select#locaddressId').append(optionElem);

    addsObs.map((cmds: IAddress[]) => {
      cmds.forEach((cmd: IAddress, index: number, cmds) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = cmd.addressId.toString();
        optionElem.text = cmd.addressLine1 + ", " + cmd.town + ", " + cmd.postCode;
        document.querySelector('select#locaddressId').append(optionElem);
      });
    }).subscribe();

    locatObs.map((cmdCats: ILocation[]) => {
      cmdCats.forEach((comCat: ILocation, index: number, cmdCats) => {
        let optionElem: HTMLOptionElement = document.createElement('option');
        optionElem.value = comCat.locationId.toString();
        optionElem.text = comCat.locationName;
        document.querySelector('select#locationId').append(optionElem);
      });
    }).subscribe();
  }
}
