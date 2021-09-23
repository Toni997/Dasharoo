import restangular = require("restangular");

export class PlaylistsService {
  private restangular: restangular.IService;
  private playlistsEndpoint: string = "playlists";
  private playlistForQueueEndpoint: string = "playlists/queue";

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all(this.playlistsEndpoint).getList();
  }

  async getOne(id: number) {
    return await this.restangular.one(this.playlistsEndpoint, id).get();
  }

  async getOneForQueue(id: number) {
    return await this.restangular.one(this.playlistForQueueEndpoint, id).get();
  }

  async postOne(formData: FormData) {
    return await this.restangular
      .all(this.playlistsEndpoint)
      .post(formData, null, {
        "Content-Type": undefined,
        Accept: "*/*",
      });
    // const req = {
    //   method: "POST",
    //   url: "https://localhost:44350/api/playlists",

    //   data: formData,
    // };
    // return await this.$http(req);
  }
}
