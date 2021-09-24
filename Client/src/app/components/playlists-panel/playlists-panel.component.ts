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

  async $onInit() {
    this.$scope.myPlaylists = null;
    this.$scope.myPlaylists = await this.playlistsService.getAllForSidebar();
    this.$scope.$apply();
  }

  togglePanel() {
    const playlistsPanel =
      this.$document.find("playlists-panel")[0].lastElementChild;
    const expandIcon: any =
      this.$document.find("separator")[0].firstElementChild.lastElementChild;

    expandIcon.style.transform = "rotate(90deg)";
    if (!playlistsPanel.classList.contains("display-none")) {
      playlistsPanel.classList.remove("display-block");
      playlistsPanel.classList.add("display-none");
      expandIcon.style.transform = "rotate(180deg)";
    } else {
      playlistsPanel.classList.remove("display-none");
      playlistsPanel.classList.add("display-block");
      expandIcon.style.transform = "rotate(0deg)";
    }
  }
}

export const PlaylistsPanelComponent: ng.IComponentOptions = {
  template: require("./playlists-panel.component.html").default,
  controller: PlaylistsPanelController,
  controllerAs: "PPC",
};
