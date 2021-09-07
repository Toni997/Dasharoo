import restangular = require("restangular");

export class PlaylistsService {
  restangular: restangular.IService;

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all("playlists").getList();
  }

  async getOne(id: number) {
    return await this.restangular.one("playlists", id).get();
  }
}
