import thunk from "redux-thunk";
import { createStore, combineReducers, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";

import { userDetailsReducer } from "./reducers/userDetailsReducer";
import { recordsReducer } from "./reducers/recordsReducer";

export class AppConfig {
  constructor(
    $locationProvider: ng.ILocationProvider,
    $compileProvider: ng.ICompileProvider,
    $ocLazyLoadProvider: oc.ILazyLoadProvider,
    RestangularProvider: Restangular.IProvider,
    CONFIG,
    ENVIRONMENT: String,
    $ngReduxProvider
  ) {
    "ngInject";

    const reducer = combineReducers({
      userDetails: userDetailsReducer,
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

    // Reference: https://github.com/mgonto/restangular#setbaseurl
    RestangularProvider.setBaseUrl(CONFIG.BASE_URL);
  }
}
