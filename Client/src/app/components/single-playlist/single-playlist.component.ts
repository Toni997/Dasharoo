import "./single-playlist.component.scss";

export class SinglePlaylistController {
  image: string = "";
  title: string = "";
  author: string = "";
  tooltip: string = "";

  constructor() {
    "ngInject";
  }

  $onInit() {}
}

export const SinglePlaylistComponent: ng.IComponentOptions = {
  template: require("./single-playlist.component.html").default,
  controller: SinglePlaylistController,
  bindings: {
    image: "<",
    title: "<",
    author: "<",
    tooltip: "<",
  },
};
