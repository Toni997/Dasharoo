import "./dinput.component.scss";

export class DinputController {
  iconName: string = "search";

  constructor() {
    "ngInject";
  }

  $onInit() {
    // console.log("dinput", this.iconName);
  }
}

export const DinputComponent: ng.IComponentOptions = {
  template: require("./dinput.component.html").default,
  controller: DinputController,
  bindings: {},
};
