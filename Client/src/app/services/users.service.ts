import LoginModel from "app/data/login.model";
import restangular = require("restangular");

export class UsersService {
  restangular: restangular.IService;

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all("account").getList();
  }

  async getOne(id: string) {
    return await this.restangular.one("account", id).get();
  }

  async login(loginModel: LoginModel) {
    return await this.restangular.customPOST(loginModel);
  }
}
