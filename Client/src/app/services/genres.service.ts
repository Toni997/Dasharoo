import restangular = require("restangular");

export class GenresService {
  restangular: restangular.IService;

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
    // console.log(this.restangular);
  }

  async getAll() {
    return await this.restangular.all("genres").getList();
  }

  async getOne(id: number) {
    return await this.restangular.one("genres", id).get();
  }
}
