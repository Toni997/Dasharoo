import { StateProvider, UrlRouterProvider } from "@uirouter/angularjs";

export class AppRoutes {
  constructor(
    $stateProvider: StateProvider,
    $urlRouterProvider: UrlRouterProvider
  ) {
    "ngInject";

    function _skipIfAuthenticated($q, $state, $auth) {
      var defer = $q.defer();
      if ($auth.isAuthenticated()) {
        defer.reject(); /* (1) */
        $state.go("app");
      } else {
        defer.resolve(); /* (2) */
      }
      return defer.promise;
    }

    function _redirectIfNotAuthenticated($q, $state, $auth) {
      var defer = $q.defer();
      if ($auth.isAuthenticated()) {
        defer.resolve(); /* (3) */
      } else {
        defer.reject();
        $state.go("login"); /* (4) */
      }
      return defer.promise;
    }

    $urlRouterProvider.otherwise("/");

    $stateProvider
      .state("app", {
        url: "/",
        onEnter: _redirectIfNotAuthenticated,
        component: "app",
      })
      .state("search", {
        url: "/search",
        onEnter: _redirectIfNotAuthenticated,
        component: "searchView",
      })
      .state("my-account", {
        url: "/my-account",
        onEnter: _redirectIfNotAuthenticated,
        component: "myAccountView",
      })
      .state("account-details", {
        url: "/account/{id}",
        onEnter: _redirectIfNotAuthenticated,
        component: "accountDetails",
      })
      .state("login", {
        url: "/login",
        // resolve: {
        //   skipIfAuthenticated: _skipIfAuthenticated,
        // },
        onEnter: _skipIfAuthenticated,
        component: "login",
      });

    ("searchView");
  }
}
