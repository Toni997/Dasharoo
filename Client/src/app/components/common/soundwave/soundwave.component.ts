import "./soundwave.component.scss";

export class SoundwaveController {
  constructor() {
    "ngInject";
    // const el: HTMLElement = document.querySelector("#first");
    // el.setAttribute("height", "10");
  }

  $onInit() {}
}

export const SoundwaveComponent: ng.IComponentOptions = {
  template: require("./soundwave.component.html").default,
  controller: SoundwaveController,
};
