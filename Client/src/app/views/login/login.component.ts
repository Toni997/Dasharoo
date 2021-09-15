import LoginModel from "app/data/login.model";
import { UsersService } from "app/services/users.service";
import "./login.component.scss";

export class LoginController {
  constructor($scope, $auth, usersService: UsersService) {
    "ngInject";

    $scope.loginModel = {
      email: "",
      password: "",
    } as LoginModel;

    $scope.authenticate = async function (provider) {
      await $auth.authenticate(provider);
      console.log(await $auth.getToken());
      console.log("successfully logged in");
    };

    $scope.logout = async function (provider) {
      await $auth.unlink(provider);
      await $auth.logout();
      console.log("successfully logged out");
    };

    $scope.onSubmit = async () => {
      console.log($scope.loginModel);
      const data = await usersService.login($scope.loginModel);
      console.log(data);
    };
  }

  $onInit() {}
}

export const LoginComponent: ng.IComponentOptions = {
  template: require("./login.component.html").default,
  controller: LoginController,
};
