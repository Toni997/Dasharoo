import LoginModel from "app/data/login.model";
import restangular = require("restangular");

export class UsersService {
  restangular: restangular.IService;
  account: string = "Account";
  loginEndpoint: string = "Auth/Login";
  logoutEndpoint: string = "Auth/Logout";

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all(this.account).getList();
  }

  async getOne(id: string) {
    return await this.restangular.one(this.account, id).get();
  }

  async login(loginModel: LoginModel) {
    return await this.restangular.all(this.loginEndpoint).post(loginModel);
  }

  async logout(userId: string) {
    return await this.restangular.all(this.logoutEndpoint).post({ userId });
  }
}
