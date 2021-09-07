import * as angular from "angular";

import "../vendor";

import { AppConfig } from "./app.config";
import { AppRoutes } from "./app.routing";
import { AppComponent } from "./app.component";
import { MusicPlayerComponent } from "./components/music-player/music-player.component";
import { RecordsService } from "./records.service";
import { RecordActionsService } from "./record-actions.service";
import { LeftSidebarComponent } from "./components/left-sidebar/left-sidebar.component";
import { SeparatorComponent } from "./components/separator/separator.component";
import { RightSidebarComponent } from "./components/right-sidebar/right-sidebar.component";
import { QuickPlayComponent } from "./components/quick-play/quick-play.component";
import { SingleArtistComponent } from "./components/single-artist/single-artist.component";
import { RecommendedForYouComponent } from "./components/recommended-for-you/recommended-for-you.component";
import { SinglePlaylistComponent } from "./components/single-playlist/single-playlist.component";
import { IconComponent } from "./components/icon/icon.component";
import { HomeHeaderComponent } from "./components/home-header/home-header.component";
import { NavigationComponent } from "./components/navigation/navigation.component";
import { PlaylistsPanelComponent } from "./components/playlists-panel/playlists-panel.component";
import { SearchViewComponent } from "./views/search-view/search-view.component";
import { MyAccountViewComponent } from './views/my-account-view/my-account-view.component';
import { HamburgerComponent } from './components/hamburger/hamburger.component';
import { SidebarsService } from './services/sidebars.service';
import { PlaylistsService } from './services/playlists.service';
import { ReduxService } from './services/redux.service';

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
]);

module.constant("ENVIRONMENT", ENV);
module.constant("CONFIG", CONFIG);

module.config(AppConfig);
module.config(AppRoutes);

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
module.component('myAccountView', MyAccountViewComponent);
module.component('hamburger', HamburgerComponent);
module.service('sidebarsService', SidebarsService);
module.service('playlistsService', PlaylistsService);
module.service('reduxService', ReduxService);

export const AppModule = module.name;
