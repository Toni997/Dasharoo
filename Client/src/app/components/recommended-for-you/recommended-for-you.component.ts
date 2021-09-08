import QueueAddType from "app/queueAddType.enum";
import { PlaylistsService } from "app/services/playlists.service";
import { ReduxService } from "app/services/redux.service";
import "./recommended-for-you.component.scss";

export class RecommendedForYouController {
  $scope: any;
  playlistsService: PlaylistsService;
  playlists: any[];
  reduxService: ReduxService;
  dispatch: any;

  constructor(
    $scope: any,
    playlistsService: PlaylistsService,
    reduxService: ReduxService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.playlistsService = playlistsService;
    this.$scope.playlists = null;
    this.reduxService = reduxService;
  }

  async $onInit() {
    console.log("aaaa");

    this.$scope.playlists = await this.playlistsService.getAll();
    this.$scope.$apply();
    this.dispatch = this.reduxService.dispatch();
  }

  onClick(id: number) {
    this.dispatch.addToQueue(id, QueueAddType.Playlist);
  }
}

export const RecommendedForYouComponent: ng.IComponentOptions = {
  template: require("./recommended-for-you.component.html").default,
  controller: RecommendedForYouController,
};
