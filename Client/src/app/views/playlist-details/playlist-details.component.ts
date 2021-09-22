import { StateParams } from "@uirouter/core";
import { IScope } from "angular";
import QueueAddType from "app/queueAddType.enum";
import { PlaylistsService } from "app/services/playlists.service";
import { ReduxService } from "app/services/redux.service";
import "./playlist-details.component.scss";

export class PlaylistDetailsController {
  $scope: IScope;
  reduxService: ReduxService;
  dispatch: any;
  playlistsService: PlaylistsService;
  playlist: any;
  playlistImage: HTMLImageElement[];
  playlistId: number;
  artistImage: HTMLImageElement[];

  constructor(
    $stateParams: StateParams,
    playlistsService: PlaylistsService,
    $scope: IScope,
    reduxService: ReduxService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.playlistId = $stateParams.id;
    this.playlistsService = playlistsService;
    this.reduxService = reduxService;
  }

  async $onInit() {
    this.playlist = await this.playlistsService.getOne(this.playlistId);
    this.playlist.releaseYear = new Date(
      this.playlist.releaseDate
    ).getFullYear();
    this.$scope.$apply();
    this.dispatch = this.reduxService.dispatch();
    this.playlistImage[0].src =
      "https://localhost:44350/api/Files/Playlists/Images?source=" +
      this.playlist.imagePath;

    this.artistImage[0].src =
      "https://localhost:44350/api/Files/Accounts/Images?source=" +
      this.playlist.author.imagePath;
    console.log(this.playlist);
  }

  onPlayPlaylist() {
    this.dispatch.addToQueue(this.playlistId, QueueAddType.Playlist);
  }

  onPlayRecord(id: number) {
    this.dispatch.addToQueue(id, QueueAddType.Record);
  }
}

export const PlaylistDetailsComponent: ng.IComponentOptions = {
  template: require("./playlist-details.component.html").default,
  controller: PlaylistDetailsController,
  controllerAs: "PDC",
};
