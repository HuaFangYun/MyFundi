import { Component, OnInit, Inject, AfterContentInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProfile, ICertification, ICourse, IWorkCategory, IFundiRating, ILocation, IUserDetail, MyFundiService, IFundiRatingDictionary } from '../../services/myFundiService';
import { Observable } from 'rxjs';
//import * as $ from 'jquery';
import { Router } from '@angular/router';
import { AfterViewInit } from '@angular/core';
import { AfterViewChecked } from '@angular/core';
declare var jQuery: any;

@Component({
  selector: 'client-fundi-search',
  templateUrl: './clientFundiSearch.component.html'
})
export class ClientFundiSearchComponent implements OnInit, AfterViewChecked {
  userDetails: any;
  userRoles: string[];
  profile: IProfile;
  location: ILocation;
  fundiRatings: IFundiRating[];
  workCategories: IWorkCategory[];
  certifications: ICertification[];
  courses: ICourse[];
  categories: string;
  fundiProfileRatingDictionary: any;
  profileIdKeys: string[];
  currentRating: number;

  decoderUrl(url: string): string {
    return decodeURIComponent(url);
  }

  ngOnInit(): void {
    this.userDetails = JSON.parse(localStorage.getItem("userDetails"));
    this.userRoles = JSON.parse(localStorage.getItem("userRoles"));
    jQuery('#fundiSearchForm div#fundiCategories').children().remove();

    let workCatObs = this.myFundiService.GetAllFundiWorkCategories();
    workCatObs.map((workCats: IWorkCategory[]) => {
      this.workCategories = workCats;

      //Dynamic check boxes for Categories To Search for:
      let divFundiCategories: HTMLElement = document.querySelector('#fundiSearchForm div#fundiCategories');


      this.workCategories.forEach((cat) => {
        let chBoxLabel = document.createElement('label');
        chBoxLabel.textContent = cat.workCategoryType;
        let chBox = document.createElement('input');
        let type = document.createAttribute('type');
        let value = document.createAttribute('value');
        let attrName = document.createAttribute('name');
        let cbzindex = document.createAttribute('style');
        cbzindex.value = "z-index: 1";
        value.value = cat.workCategoryType;
        type.value = "checkbox";
        chBox.attributes.setNamedItem(type);
        chBox.attributes.setNamedItem(value);
        chBox.attributes.setNamedItem(cbzindex);

        attrName.value = cat.workCategoryType;
        chBox.attributes.setNamedItem(attrName);
        let hr = document.createElement('hr');
        let br = document.createElement('br');
        chBoxLabel.className = 'custom-control-label';
        chBox.className = 'custom-control-input';
        let divWrapper = document.createElement('div');
        let divFormGroup = document.createElement('div');
        divFormGroup.className = "form-group";
        divWrapper.className = "custom-control custom-checkbox";

        divWrapper.appendChild(chBox);
        divWrapper.appendChild(chBoxLabel);
        divWrapper.appendChild(br);
        divWrapper.appendChild(hr);

        divFormGroup.appendChild(divWrapper);
        divFundiCategories.appendChild(divFormGroup);

      });
    }).subscribe();

    /*  let downloadLink: HTMLAnchorElement = document.querySelector('a#downloadCV');
      downloadLink.setAttribute('ng-reflect-router-link', '/manage-profile');
      downloadLink.setAttribute('href',`/FundiProfile/GetFundiCV?username=${this.userDetails.username}`);*/

  }
  constructor(private myFundiService: MyFundiService, private router: Router) {
    this.userDetails = {};
  }
  ngAfterViewChecked(): void {
    let curthis = this;
    jQuery('div.rating').starRating(
      {
        initialRating: 0,
        starSize: 25,
        useFullStars: true,
        callback: function (rating) {
          curthis.currentRating = rating;
        }
      });
  }

  searchFundiByCategories($event) {
    let currentThis = this;
    let divFundiCategories: HTMLElement = document.querySelector('form#fundiSearchForm div#fundiCategories');
    let chosenCategories: string[] = [];

    let checkedboxes = jQuery('form#fundiSearchForm div#fundiCategories').find('input[type="checkbox"]:checked');
    for (let n = 0; n < checkedboxes.length; n++) {
      chosenCategories.push(checkedboxes[n].name);
    }
    let fundiRatingsObs: Observable<any> = this.myFundiService.GetFundiRatingsAndReviews(chosenCategories);

    fundiRatingsObs.map((q: any) => {
      this.fundiProfileRatingDictionary = q;
      this.profileIdKeys = Object.keys(this.fundiProfileRatingDictionary);
    }).subscribe();

    $event.stopPropagation();
  }
  rateFundi($event) {

    let button = $event.target;
    let review = jQuery(button).parent('form').find('textarea').val();
    let profileId: number = button.id;
    let rating: number = this.currentRating;

    alert('rated ' + rating);
    let userIdObs: Observable<any> = this.myFundiService.GetUserGuidId(this.userDetails.username);

    userIdObs.map((userId: any) => {

      let fundiRated: any = {
        fundiProfileId: profileId,
        rating: rating,
        review: review,
        userId: userId
      };

      let fundiRatedObs: Observable<any> = this.myFundiService.RateFundiByProfileId(fundiRated);
      fundiRatedObs.map((res: any) => {
        alert(res.message);
      }).subscribe();
    }).subscribe();

  }
  populateFundiUserDetails($event, profileId: number) {
    let userObs: Observable<any> = this.myFundiService.GetFundiUserByProfileId(profileId);

    userObs.map((res: any) => {
      localStorage.setItem("profileUserDetails", JSON.stringify(res));
      this.router.navigateByUrl('/fundiprofile-by-id');
    }).subscribe();
    $event.preventDefault();
  }
}

