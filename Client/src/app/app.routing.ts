import { StateProvider, UrlRouterProvider } from "@uirouter/angularjs";

export class AppRoutes {
  constructor(
    $stateProvider: StateProvider,
    $urlRouterProvider: UrlRouterProvider
  ) {
    "ngInject";

    function skipIfAuthenticated($q, $state, $ngRedux) {
      var user = $ngRedux.getState().userDetails.user;
      var defer = $q.defer();
      if (user) {
        defer.reject(); /* (1) */
        $state.go("app");
      } else {
        defer.resolve(); /* (2) */
      }
      return defer.promise;
    }

    function redirectIfNotAuthenticated($q, $state, $ngRedux) {
      var user = $ngRedux.getState().userDetails.user;
      var defer = $q.defer();
      if (user) {
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
        onEnter: redirectIfNotAuthenticated,
        component: "app",
      })
      .state("search", {
        url: "/search",
        onEnter: redirectIfNotAuthenticated,
        component: "searchView",
      })
      .state("my-account", {
        url: "/my-account",
        onEnter: redirectIfNotAuthenticated,
        component: "myAccountView",
      })
      .state("account-details", {
        url: "/account/{id}",
        onEnter: redirectIfNotAuthenticated,
        component: "accountDetails",
      })
      .state("add-playlist", {
        url: "/playlist/add",
        onEnter: redirectIfNotAuthenticated,
        component: "addPlaylist",
      })
      .state("playlist-details", {
        url: "/playlist/{id}",
        onEnter: redirectIfNotAuthenticated,
        component: "playlistDetails",
      })
      .state("login", {
        url: "/login",
        onEnter: skipIfAuthenticated,
        component: "login",
      });

    ("searchView");
  }
}
