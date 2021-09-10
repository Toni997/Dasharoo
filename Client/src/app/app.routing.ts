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
      })
      .state("account-details", {
        url: "/account/{id}",
        component: "accountDetails",
        // resolve: {
        //   account: function (
        //     UsersService: UsersService,
        //     $transition$: Transition
        //   ) {
        //     return UsersService.getOne($transition$.params().id);
        //   },
        // },
      });

    ("searchView");
  }
}
