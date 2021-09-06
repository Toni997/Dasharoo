import "./playlists-panel.component.scss";

export class PlaylistsPanelController {
  $document: ng.IDocumentService;

  constructor($document: ng.IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  $onInit() {}

  togglePanel() {
    const playlistsPanel =
      this.$document.find("playlists-panel")[0].lastElementChild;
    const expandIcon: any =
      this.$document.find("separator")[0].firstElementChild.lastElementChild;

    expandIcon.style.transform = "rotate(90deg)";
    console.log(playlistsPanel);
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
};
