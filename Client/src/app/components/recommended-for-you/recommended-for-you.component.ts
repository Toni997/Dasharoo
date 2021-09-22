import { PlaylistsService } from "app/services/playlists.service";
import { ReduxService } from "app/services/redux.service";
import "./recommended-for-you.component.scss";

export class RecommendedForYouController {
  $scope: any;
  playlistsService: PlaylistsService;
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
    this.$scope.playlists = await this.playlistsService.getAll();
    this.$scope.$apply();
    this.dispatch = this.reduxService.dispatch();

    this.reduxService.redux.subscribe(() => {
      this.$scope.records = this.reduxService.redux.getState().records;
      console.log();
    });
  }

  onClick(id: number) {
    this.dispatch.addToQueue(id);
  }
}

export const RecommendedForYouComponent: ng.IComponentOptions = {
  template: require("./recommended-for-you.component.html").default,
  controller: RecommendedForYouController,
};
