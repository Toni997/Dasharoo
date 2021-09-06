import { StateProvider, UrlRouterProvider } from "@uirouter/angularjs";

export class AppRoutes {
  constructor(
    $stateProvider: StateProvider,
    $urlRouterProvider: UrlRouterProvider
  ) {
    "ngInject";

    $urlRouterProvider.otherwise("/");

    $stateProvider
      .state("app", {
        url: "/",
        component: "app",
      })
      .state("search", {
        url: "/search",
        component: "searchView",
      })
      .state("my-account", {
        url: "/my-account",
        component: "myAccountView",
      });

    ("searchView");
  }
}
