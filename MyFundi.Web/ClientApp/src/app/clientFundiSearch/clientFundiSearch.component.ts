import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProfile, ICertification, ICourse, IWorkCategory, IFundiRating, ILocation, IUserDetail, MyFundiService, IFundiRatingDictionary } from '../../services/myFundiService';
import { Observable } from 'rxjs';
import * as $ from 'jquery';
import { Router } from '@angular/router';

@Component({
  selector: 'client-fundi-search',
  templateUrl: './clientFundiSearch.component.html'
})
export class ClientFundiSearchComponent implements OnInit {
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

  decoderUrl(url: string):string {
    return decodeURIComponent(url);
  }
  ngOnInit(): void {
    this.userDetails = JSON.parse(localStorage.getItem("userDetails"));
    this.userRoles = JSON.parse(localStorage.getItem("userRoles"));
    
    /*
    let resObs = this.myFundiService.GetFundiProfile(this.userDetails.username);
    let certsObs = this.myFundiService.GetFundiCertifications(this.userDetails.username);
    let coursesObs = this.myFundiService.GetFundiCourses(this.userDetails.username);
    let ratingsObs = this.myFundiService.GetFundiRatings(this.userDetails.username);
    
    resObs.map((fundiProf: IProfile) => {
      this.profile = fundiProf;
    }).subscribe();

    ratingsObs.map((ratings: IFundiRating[]) => {
      this.fundiRatings = ratings;
    }).subscribe();
    */

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
  constructor(private myFundiService: MyFundiService, private router:Router) {
    this.userDetails = {};
  }

  searchFundiByCategories($event){

    let divFundiCategories: HTMLElement = document.querySelector('form#fundiSearchForm div#fundiCategories');
    let chosenCategories: string[] = [];

    let checkedboxes = $('form#fundiSearchForm div#fundiCategories').find('input[type="checkbox"]:checked');
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
  populateFundiUserDetails($event, profileId: number) {
    let userObs: Observable<any> = this.myFundiService.GetFundiUserByProfileId(profileId);

    userObs.map((res: any) => {
      localStorage.setItem("profileUserDetails", JSON.stringify(res));
      this.router.navigateByUrl('/fundiprofile-by-id');
    }).subscribe();
    $event.preventDefault();
  }
}

