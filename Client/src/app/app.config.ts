import thunk from "redux-thunk";
import { createStore, combineReducers, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";

import { userLoginReducer } from "./reducers/userReducers";
import { recordsReducer } from "./reducers/recordsReducer";
import { HubConfigService } from "./services/hub-config.service";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

const hubConnectionBuilder: HubConnectionBuilder = new HubConnectionBuilder();

export const hubConnection = hubConnectionBuilder
  .withUrl("https://localhost:44350/myhub")
  .build();

export class AppConfig {
  hubConfigService: HubConfigService;
  hubConnection: HubConnection;

  constructor(
    $locationProvider: ng.ILocationProvider,
    $compileProvider: ng.ICompileProvider,
    $ocLazyLoadProvider: oc.ILazyLoadProvider,
    RestangularProvider: Restangular.IProvider,
    CONFIG,
    ENVIRONMENT: String,
    $ngReduxProvider,
    $authProvider
    // ngJwtAuthServiceProvider: NgJwtAuthServiceProvider
  ) {
    "ngInject";

    // ngJwtAuthServiceProvider.configure({
    //   base: "/api",
    //   login: "/login-custom",
    //   tokenExchange: "/token-custom",
    //   refresh: "/refresh-custom",
    // });

    $authProvider.baseUrl = CONFIG.BASE_URL;
    $authProvider.loginUrl = "Account/Login";

    $authProvider.facebook({
      clientId: "1006915756787962",
      responseType: "token",
    });

    // console.log($authProvider);

    const reducer = combineReducers({
      userDetails: userLoginReducer,
      records: recordsReducer,
    });
    const middleware = [thunk];

    $ngReduxProvider.createStore((/*middlewares, enhancers*/) => {
      return createStore(
        reducer,
        {},
        composeWithDevTools(applyMiddleware(...middleware))
      );
    });

    // Reference: https://docs.angularjs.org/api/ng/provider/$locationProvider#html5Mode
    $locationProvider.html5Mode(true);

    // Reference : http://blog.thoughtram.io/angularjs/2014/12/22/exploring-angular-1.3-disabling-debug-info.html
    $compileProvider.debugInfoEnabled(
      ENVIRONMENT !== "prod" && ENVIRONMENT !== "production"
    );

    // Reference: https://oclazyload.readme.io/docs/oclazyloadprovider
    $ocLazyLoadProvider.config({
      debug: ENVIRONMENT !== "prod" && ENVIRONMENT !== "production",
    });

    // const token = localStorage.getItem("accessToken") || null;

    // Reference: https://github.com/mgonto/restangular#setbaseurl
    RestangularProvider.setBaseUrl(CONFIG.BASE_URL);
    // RestangularProvider.setDefaultHeaders({ Authorization: "Bearer " + token });
  }
}
