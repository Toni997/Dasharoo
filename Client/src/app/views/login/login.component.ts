import LoginModel from "app/data/login.model";
import { ReduxService } from "app/services/redux.service";
// import { UsersService } from "app/services/users.service";
import "./login.component.scss";

export class LoginController {
  constructor(
    $scope: any,
    $state: any,
    $auth: any,
    reduxService: ReduxService
  ) {
    "ngInject";

    $state.defaultErrorHandler(function (error) {
      // This is a naive example of how to silence the default error handler.
      console.log(error);
    });

    const dispatch = reduxService.dispatch();

    $scope.loginModel = {
      email: "",
      password: "",
    } as LoginModel;

    $scope.authenticate = async function (provider) {
      await $auth.authenticate(provider);
      $state.go("app");
    };

    $scope.logout = async function () {
      // await $auth.unlink(provider);
      await $auth.logout();
      console.log("successfully logged out");
    };

    $scope.onSubmit = async () => {
      dispatch.login($scope.loginModel);
      console.log("successfully logged in");
      $state.go("app");
    };
  }

  $onInit() {}
}

export const LoginComponent: ng.IComponentOptions = {
  template: require("./login.component.html").default,
  controller: LoginController,
};
