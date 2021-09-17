// import LoginModel from "app/data/login.model";
import restangular = require("restangular");
import { ReduxService } from "./redux.service";
import { UsersService } from "./users.service";

export class AuthService {
  restangular: restangular.IService;
  usersService: UsersService;
  reduxService: ReduxService;
  dispatch: any;

  constructor(
    Restangular: restangular.IService,
    usersService: UsersService,
    reduxService: ReduxService
  ) {
    "ngInject";

    this.restangular = Restangular;
    this.usersService = usersService;
    this.reduxService = reduxService;
    this.dispatch = this.reduxService.dispatch();
  }

  // async login(loginModel: LoginModel) {
  //   const tokens: any = await this.usersService.login(loginModel);
  //   this.dispatch.login(loginModel);
  // }

  // unused
  logout() {
    localStorage.removeItem("accessToken");
    // TODO req to db to invalid the refresh token
    localStorage.removeItem("refreshToken");
  }

  isLoggedIn() {
    if (this.reduxService.getCurrentUser()) return true;
    return false;
  }
}
