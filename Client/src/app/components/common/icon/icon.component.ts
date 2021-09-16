import "./icon.component.scss";

export class IconController {
  tooltip: string = "";
  src: string = "";
  width: string = "";
  alt: string = "Icon";
  constructor() {
    "ngInject";
  }

  $onInit() {
    // console.log(this.src);
  }
}

export const IconComponent: ng.IComponentOptions = {
  template: require("./icon.component.html").default,
  controller: IconController,
  bindings: {
    tooltip: "@",
    src: "<",
    width: "<",
    alt: "<",
  },
};
