import { StateParams } from "@uirouter/core";
import { UsersService } from "app/services/users.service";
import "./account-details.component.scss";

("use strict");

export class AccountDetailsController {
  usersService: UsersService;
  $stateParams: StateParams;
  paramId: string;
  account: any;
  $scope: any;

  constructor(
    $scope: any,
    $stateParams: StateParams,
    usersService: UsersService
  ) {
    "ngInject";

    this.$stateParams = $stateParams;
    this.paramId = this.$stateParams.id;
    this.usersService = usersService;
    this.$scope = $scope;
  }

  async $onInit() {
    this.account = await this.usersService.getOne(this.paramId);
    this.$scope.$apply();
  }
}

export const AccountDetailsComponent: ng.IComponentOptions = {
  template: require("./account-details.component.html").default,
  controller: AccountDetailsController,
};
