class AppController {
  title: String;

  constructor() {
    "ngInject";
  }

  $onInit() {
    this.title = "Dasharoo";
  }
}

export const AppComponent = {
  controller: AppController,
  template: require("./app.component.html").default,
};
