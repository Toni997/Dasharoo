import "./separator.component.scss";

export class SeparatorController {
  text: string;

  constructor() {
    "ngInject";
  }

  $onInit() {}

  onClick() {
    // e.target.style.animation = "rotate180 0.5s forwards";
  }
}

export const SeparatorComponent: ng.IComponentOptions = {
  template: require("./separator.component.html").default,
  controller: SeparatorController,
  bindings: {
    text: "<",
  },
};
