import AddRecordToPlaylist from "app/data/addRecordToPlaylist";
import restangular = require("restangular");

export class PlaylistsService {
  private restangular: restangular.IService;
  private playlistsEndpoint: string = "playlists";
  private playlistForQueueEndpoint: string = "playlists/queue";
  private playlistsForSidebarEndpoint: string = "playlists/for-sidebar";
  private addRecordToPlaylistEndpoint: string = "playlists/add-record";

  constructor(Restangular: restangular.IService) {
    "ngInject";

    this.restangular = Restangular;
  }

  async getAll() {
    return await this.restangular.all(this.playlistsEndpoint).getList();
  }

  async getAllForSidebar() {
    return await this.restangular
      .all(this.playlistsForSidebarEndpoint)
      .getList();
  }

  async getOne(id: number) {
    return await this.restangular.one(this.playlistsEndpoint, id).get();
  }

  async getOneForQueue(id: number) {
    return await this.restangular.one(this.playlistForQueueEndpoint, id).get();
  }

  async deleteOne(id: number) {
    return await this.restangular.one(this.playlistsEndpoint, id).remove();
  }

  async postOne(formData: FormData) {
    return await this.restangular
      .all(this.playlistsEndpoint)
      .post(formData, null, {
        "Content-Type": undefined,
        Accept: "*/*",
      });
  }

  async addToPlaylist(addRecordToPlaylist: AddRecordToPlaylist) {
    return await this.restangular
      .all(this.addRecordToPlaylistEndpoint)
      .post(addRecordToPlaylist);
  }
}
