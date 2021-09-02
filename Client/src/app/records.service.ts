import restangular = require("restangular");

export class RecordsService {
  restangular: restangular.IService;

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all("records").getList();
  }

  async getOne(id: number) {
    return await this.restangular.one("records", id).get();
  }
}
