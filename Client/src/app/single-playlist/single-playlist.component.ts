import "./single-playlist.component.scss";

export class SinglePlaylistController {
  image: string = "";
  details: any;

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
    details: "<",
  },
};
