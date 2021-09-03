import * as angular from "angular";

import "../vendor";

import { AppConfig } from "./app.config";
import { AppRoutes } from "./app.routing";
import { AppComponent } from "./app.component";
import { MusicPlayerComponent } from "./music-player/music-player.component";
import { RecordsService } from "./records.service";
import { RecordActionsService } from "./record-actions.service";
import { LeftSidebarComponent } from './left-sidebar/left-sidebar.component';
import { SeparatorComponent } from './separator/separator.component';
import { RightSidebarComponent } from './right-sidebar/right-sidebar.component';
import { QuickPlayComponent } from './quick-play/quick-play.component';
import { SingleArtistComponent } from './single-artist/single-artist.component';
import { RecommendedForYouComponent } from './recommended-for-you/recommended-for-you.component';
import { SinglePlaylistComponent } from './single-playlist/single-playlist.component';
import { IconComponent } from './icon/icon.component';
import { HomeHeaderComponent } from './home-header/home-header.component';

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
module.component('leftSidebar', LeftSidebarComponent);
module.component('separator', SeparatorComponent);
module.component('rightSidebar', RightSidebarComponent);
module.component('quickPlay', QuickPlayComponent);
module.component('singleArtist', SingleArtistComponent);
module.component('recommendedForYou', RecommendedForYouComponent);
module.component('singlePlaylist', SinglePlaylistComponent);
module.component('icon', IconComponent);
module.component('homeHeader', HomeHeaderComponent);

export const AppModule = module.name;
