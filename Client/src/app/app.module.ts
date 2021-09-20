import * as angular from "angular";

import "../vendor";

import { AppConfig } from "./app.config";
import { AppRoutes } from "./app.routing";
import { AppComponent } from "./app.component";
import { MusicPlayerComponent } from "./components/music-player/music-player.component";
import { RecordsService } from "./records.service";
import { RecordActionsService } from "./actions/record-actions.service";
import { LeftSidebarComponent } from "./components/left-sidebar/left-sidebar.component";
import { SeparatorComponent } from "./components/separator/separator.component";
import { RightSidebarComponent } from "./components/right-sidebar/right-sidebar.component";
import { QuickPlayComponent } from "./components/quick-play/quick-play.component";
import { SingleArtistComponent } from "./components/single-artist/single-artist.component";
import { RecommendedForYouComponent } from "./components/recommended-for-you/recommended-for-you.component";
import { SinglePlaylistComponent } from "./components/single-playlist/single-playlist.component";
import { IconComponent } from "./components/common/icon/icon.component";
import { HomeHeaderComponent } from "./components/home-header/home-header.component";
import { NavigationComponent } from "./components/navigation/navigation.component";
import { PlaylistsPanelComponent } from "./components/playlists-panel/playlists-panel.component";
import { SearchViewComponent } from "./views/search-view/search-view.component";
import { MyAccountViewComponent } from "./views/my-account-view/my-account-view.component";
import { HamburgerComponent } from "./components/hamburger/hamburger.component";
import { SidebarsService } from "./services/sidebars.service";
import { PlaylistsService } from "./services/playlists.service";
import { ReduxService } from "./services/redux.service";
import { DinputComponent } from "./components/common/dinput/dinput.component";
import { UsersService } from "./services/users.service";
import { LoaderComponent } from "./components/common/loader/loader.component";
import { GenresService } from "./services/genres.service";
import { AccountDetailsComponent } from "./views/account-details/account-details.component";
import { HubConfigService } from "./services/hub-config.service";
import { NotificationPanelComponent } from "./components/notification-panel/notification-panel.component";
import { LoginComponent } from "./views/login/login.component";
import { UserActionsService } from "./actions/user-actions.service";
import { AuthService } from "./services/auth.service";
import restangular = require("restangular");
import { StateService } from "@uirouter/core";

let module: ng.IModule = angular.module("dasharoo", [
  "ngAnimate",
  "ngResource",
  "ngSanitize",
  "ngMessages",
  "ngAria",
  "ngCookies",
  "ui.router",
  "restangular",
  "oc.lazyLoad",
  "ngRedux",
  "satellizer",
  "angular-jwt",
  // "ngJwtAuth",
]);

module.constant("ENVIRONMENT", ENV);
module.constant("CONFIG", CONFIG);

module.config(AppConfig);
module.config(AppRoutes);

class RestConfig {
  title: String;

  constructor(
    reduxService: ReduxService,
    jwtHelper: any,
    Restangular: restangular.IService,
    $state: StateService
  ) {
    "ngInject";
    // console.log(Restangular);
    const accessToken = localStorage.getItem("accessToken");
    if (accessToken) {
      const userInfo = jwtHelper.decodeToken(accessToken);
      reduxService.dispatch().loadUserInfo(userInfo);
    }

    Restangular.addRequestInterceptor((element) => {
      const accessToken = localStorage.getItem("accessToken");
      Restangular.setDefaultHeaders({ Authorization: "Bearer " + accessToken });
      return element;
    });

    Restangular.setErrorInterceptor(async (response, deferred) => {
      if (response.status == 401) {
        const currentAccessToken = localStorage.getItem("accessToken");
        const isExpired: boolean = jwtHelper.isTokenExpired(currentAccessToken);
        if (isExpired) {
          const refreshToken = localStorage.getItem("refreshToken");
          Restangular.all("Auth/Token")
            .post({
              userId: "f2fc5610-1830-451a-ad1b-3732c32b2970",
              token: refreshToken,
            })
            .then(function (x) {
              localStorage.setItem("accessToken", x.accessToken);
              const newAuthorizationHeader = "Bearer " + x.accessToken;
              Restangular.setDefaultHeaders({
                Authorization: newAuthorizationHeader,
              });
              $state.reload();
              // const req = {
              //   method: response.config.method,
              //   url: response.config.url,
              //   headers: {
              //     Accept: "application/json, text/plain, */*",
              //     Authorization: newAuthorizationHeader,
              //   },
              //   data: response.data,
              // };
              // $http(req)
              //   .then(deferred.reject)
              //   .catch((y) => console.log(y));
            })
            .catch((err) => deferred.resolve);
        }
        return false;
      }
      return true;
    });
  }
}

module.run(RestConfig);

module.component("app", AppComponent);
module.component("musicPlayer", MusicPlayerComponent);
module.service("recordsService", RecordsService);
module.service("recordActionsService", RecordActionsService);
module.component("leftSidebar", LeftSidebarComponent);
module.component("separator", SeparatorComponent);
module.component("rightSidebar", RightSidebarComponent);
module.component("quickPlay", QuickPlayComponent);
module.component("singleArtist", SingleArtistComponent);
module.component("recommendedForYou", RecommendedForYouComponent);
module.component("singlePlaylist", SinglePlaylistComponent);
module.component("icon", IconComponent);
module.component("homeHeader", HomeHeaderComponent);
module.component("navigation", NavigationComponent);
module.component("playlistsPanel", PlaylistsPanelComponent);
module.component("searchView", SearchViewComponent);
module.component("myAccountView", MyAccountViewComponent);
module.component("hamburger", HamburgerComponent);
module.service("sidebarsService", SidebarsService);
module.service("playlistsService", PlaylistsService);
module.service("reduxService", ReduxService);
module.component("dinput", DinputComponent);
module.service("usersService", UsersService);
module.component("loader", LoaderComponent);
module.service("genresService", GenresService);
module.component("accountDetails", AccountDetailsComponent);
module.service("hubConfigService", HubConfigService);
module.component("notificationPanel", NotificationPanelComponent);
module.component("login", LoginComponent);
module.service("userActionsService", UserActionsService);
module.service("authService", AuthService);

export const AppModule = module.name;
