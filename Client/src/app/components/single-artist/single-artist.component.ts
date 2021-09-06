import "./single-artist.component.scss";

export class SingleArtistController {
  name: string;
  profileImage: string;

  constructor() {
    "ngInject";
  }

  $onInit() {}
}

export const SingleArtistComponent: ng.IComponentOptions = {
  template: require("./single-artist.component.html").default,
  controller: SingleArtistController,
  bindings: {
    name: "<",
    image: "<",
  },
};
