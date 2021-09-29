import { PlaylistsService } from "app/services/playlists.service";
import "./playlists-panel.component.scss";
import { FilesService } from "app/services/files.service";
import { SidebarsService } from "app/services/sidebars.service";

export class PlaylistsPanelController {
  $document: ng.IDocumentService;
  playlistsService: PlaylistsService;
  $scope: any;
  baseUrl: string;
  filesService: FilesService;
  sidebarsService: SidebarsService;
  closeLeftSidebar: any;
  // isLoading: boolean = false;
  shouldShowPlaylistPanel: boolean = true;

  constructor(
    $document: ng.IDocumentService,
    $scope: any,
    filesService: FilesService,
    playlistsService: PlaylistsService,
    sidebarsService: SidebarsService
  ) {
    "ngInject";

    this.$document = $document;
    this.$scope = $scope;
    this.filesService = filesService;
    this.playlistsService = playlistsService;
    this.sidebarsService = sidebarsService;
  }

  async $postLink() {
    this.$scope.isLoading = true;
    try {
      this.$scope.myPlaylists = await this.playlistsService.getAllForSidebar();
      this.$scope.isLoading = false;
      this.$scope.$apply();
    } catch (error) {
      this.$scope.isLoading = false;
      console.log("error in playlist panel");
      this.$scope.$apply();
    }
  }
}

export const PlaylistsPanelComponent: ng.IComponentOptions = {
  template: require("./playlists-panel.component.html").default,
  controller: PlaylistsPanelController,
  controllerAs: "PPC",
};
