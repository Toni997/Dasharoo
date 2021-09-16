import LoginModel from "app/data/login.model.js";
import {
  USER_LOGIN_REQUEST,
  USER_LOGIN_SUCCESS,
  USER_LOGIN_FAIL,
  USER_LOGOUT,
  // USER_LOGOUT,
  // USER_REGISTER_REQUEST,
  // USER_REGISTER_SUCCESS,
  // USER_REGISTER_FAIL,
  // USER_DETAILS_FAIL,
  // USER_DETAILS_SUCCESS,
  // USER_DETAILS_REQUEST,
  // USER_UPDATE_PROFILE_FAIL,
  // USER_UPDATE_PROFILE_SUCCESS,
  // USER_UPDATE_PROFILE_REQUEST,
  // USER_DETAILS_RESET,
} from "../constants/userConstants";

export class UserActionsService {
  $auth: any;

  constructor($auth: any) {
    "ngInject";

    this.$auth = $auth;
  }

  login(loginModel: LoginModel) {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({
          type: USER_LOGIN_REQUEST,
        });

        await self.$auth.login(loginModel);
        const userInfo = self.$auth.getPayload();

        console.log("payload", userInfo);

        dispatch({
          type: USER_LOGIN_SUCCESS,
          payload: userInfo,
        });
      } catch (error) {
        dispatch({
          type: USER_LOGIN_FAIL,
          payload:
            error.response && error.response.data.message
              ? error.response.data.message
              : error.message,
        });
      }
    };
  }
  logout() {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({
          type: USER_LOGIN_REQUEST,
        });

        await self.$auth.logout();

        dispatch({
          type: USER_LOGOUT,
        });
      } catch (error) {
        dispatch({
          type: USER_LOGIN_FAIL,
          payload:
            error.response && error.response.data.message
              ? error.response.data.message
              : error.message,
        });
      }
    };
  }
}
