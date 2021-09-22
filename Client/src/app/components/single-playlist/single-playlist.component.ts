import { StateService } from "@uirouter/core";
import "./single-playlist.component.scss";

export class SinglePlaylistController {
  image: string = "";
  title: string = "";
  author: string = "";
  tooltip: string = "";
  playlistid: string;
  $state: StateService;

  constructor($state: StateService) {
    "ngInject";

    this.$state = $state;
  }

  $onInit() {}

  onAuthorClick() {
    console.log("clicked");
    console.log(this.playlistid);
    this.$state.go("account-details", { id: this.playlistid });
    // e.stopPropagation();
  }
}

export const SinglePlaylistComponent: ng.IComponentOptions = {
  template: require("./single-playlist.component.html").default,
  controller: SinglePlaylistController,
  bindings: {
    image: "<",
    title: "<",
    author: "<",
    tooltip: "<",
    playlistid: "<",
  },
};
