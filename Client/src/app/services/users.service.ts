import LoginModel from "app/data/login.model";
import restangular = require("restangular");

export class UsersService {
  restangular: restangular.IService;
  account: string = "Account";
  loginStr: string = "Login";

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
    return await this.restangular
      .all(`${this.account}/${this.loginStr}`)
      .post(loginModel);
  }
}
