import restangular = require("restangular");

export class RecordsService {
  private restangular: restangular.IService;
  private recordsSearchEndpoint: string = "Records/Search?keyword=";

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

  async getAllByKeyword(keyword: string) {
    return await this.restangular
      .all(this.recordsSearchEndpoint + keyword)
      .getList();
  }
}
