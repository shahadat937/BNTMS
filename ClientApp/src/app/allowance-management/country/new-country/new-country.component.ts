import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { SelectedModel } from "../../../core/models/selectedModel";
import { CountryService } from "../../service/country.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-new-country",
  templateUrl: "./new-country.component.html",
  styleUrls: ["./new-country.component.sass"],
})
export class NewcountryComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  buttonText: string;
  loading = false;
  pageTitle: string;
  destination: string;
  countryForm: FormGroup;
  validationErrors: string[] = [];
  selectedCountryGroup: SelectedModel[];
  selectedCurrencyName: SelectedModel[];

  constructor(
    private snackBar: MatSnackBar,
    private countryService: CountryService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("countryId");
    if (id) {
      this.pageTitle = "Edit Country";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.countryService.find(+id).subscribe((res) => {
        this.countryForm.patchValue({
          countryId: res.countryId,
          countryName: res.countryName,
          shortName: res.shortName,
          countryGroupId: res.countryGroupId,
          currencyNameId: res.currencyNameId,
          currentPrice: res.currentPrice,
        });
      });
    } else {
      this.pageTitle = "Create Country";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    this.getselectedCountryGroup();
    this.getselectedCurrencyName();
  }
  intitializeForm() {
    this.countryForm = this.fb.group({
      countryId: [0],
      countryName: ["", Validators.required],
      shortName: [""],
      countryGroupId: [],
      currencyNameId: [],
      currentPrice: [],
      isActive: [true],
    });
  }
  getselectedCountryGroup() {
    this.countryService.getselectedCountryGroup().subscribe((res) => {
      this.selectedCountryGroup = res;
    });
  }
  getselectedCurrencyName() {
    this.countryService.getselectedCurrencyName().subscribe((res) => {
      this.selectedCurrencyName = res;
    });
  }

  onSubmit() {
    const id = this.countryForm.get("countryId")?.value;
    if (id) {
      this.confirmService
        .confirm(
          "Confirm Update message",
          "Are You Sure Update This Country Item?"
        )
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.countryService.update(+id, this.countryForm.value).subscribe(
              (response) => {
                this.router.navigateByUrl("/allowance-management/country-list");
                this.snackBar.open("Information Updated Successfully ", "", {
                  duration: 2000,
                  verticalPosition: "bottom",
                  horizontalPosition: "right",
                  panelClass: "snackbar-success",
                });
              },
              (error) => {
                this.validationErrors = error;
              }
            );
          }
        });
    } else {
      this.loading = true;
      this.countryService.submit(this.countryForm.value).subscribe(
        (response) => {
          this.router.navigateByUrl("/allowance-management/country-list");
          this.snackBar.open("Information Inserted Successfully ", "", {
            duration: 2000,
            verticalPosition: "bottom",
            horizontalPosition: "right",
            panelClass: "snackbar-success",
          });
        },
        (error) => {
          this.validationErrors = error;
        }
      );
    }
  }
}
