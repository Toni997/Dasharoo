import LoginModel from "app/data/login.model";
// import { AuthService } from "app/services/auth.service";
import { ReduxService } from "app/services/redux.service";
// import { UsersService } from "app/services/users.service";
import "./login.component.scss";

export class LoginController {
  dispatch: any;
  loginModel: LoginModel = {
    email: "",
    password: "",
  } as LoginModel;

  constructor(
    $state: any,
    reduxService: ReduxService

    // authService: AuthService
  ) {
    "ngInject";

    $state.defaultErrorHandler(function (error) {
      // This is a naive example of how to silence the default error handler.
      console.log(error);
    });

    this.dispatch = reduxService.dispatch();

    // $scope.authenticate = async function (provider) {
    //   await $auth.authenticate(provider);
    //   $state.go("app");
    // };
  }

  $onInit() {}

  onSubmit() {
    this.dispatch.login(this.loginModel);
    console.log("successfully logged in");
    console.log(this.loginModel);
  }

  logout = async function () {
    // await $auth.unlink(provider);
    // await $auth.logout();
    console.log("successfully logged out");
  };
}

export const LoginComponent: ng.IComponentOptions = {
  template: require("./login.component.html").default,
  controller: LoginController,
  controllerAs: "LC",
};
