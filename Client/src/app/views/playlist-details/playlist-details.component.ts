import { StateParams } from "@uirouter/core";
import { IScope } from "angular";
import { PlaylistsService } from "app/services/playlists.service";
import "./playlist-details.component.scss";

export class PlaylistDetailsController {
  $scope: IScope;
  playlistsService: PlaylistsService;
  playlist: any;
  playlistImage: HTMLImageElement[];
  playlistId: number = 1;

  constructor(
    $stateParams: StateParams,
    playlistsService: PlaylistsService,
    $scope: IScope
  ) {
    "ngInject";

    this.$scope = $scope;
    this.playlistId = $stateParams.id;
    this.playlistsService = playlistsService;
  }

  async $onInit() {
    this.playlist = await this.playlistsService.getOne(this.playlistId);
    this.playlist.releasedIn = new Date(
      this.playlist.releaseDate
    ).getFullYear();
    this.$scope.$apply();
    this.playlistImage[0].src =
      "https://localhost:44350/api/Files/Playlists/Images?source=" +
      this.playlist.imagePath;
    console.log(this.playlist.releasedIn);
  }
}

export const PlaylistDetailsComponent: ng.IComponentOptions = {
  template: require("./playlist-details.component.html").default,
  controller: PlaylistDetailsController,
  controllerAs: "PDC",
};
