import { ReduxService } from "app/services/redux.service";
import "./my-account-view.component.scss";

export class MyAccountViewController {
  reduxService: ReduxService;

  constructor($scope: any, $state: any, reduxService: ReduxService) {
    "ngInject";

    const dispatch = reduxService.dispatch();

    $scope.logout = async function () {
      // await $auth.unlink(provider);
      // await $auth.logout();
      dispatch.logout();
      console.log("successfully logged out");
      $state.go("login");
    };
  }

  $onInit() {}
}

export const MyAccountViewComponent: ng.IComponentOptions = {
  template: require("./my-account-view.component.html").default,
  controller: MyAccountViewController,
};
