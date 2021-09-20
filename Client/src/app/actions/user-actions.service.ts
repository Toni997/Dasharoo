import LoginModel from "app/data/login.model.js";
import { UsersService } from "app/services/users.service";
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
import { RECORDS_RESET } from "../constants/recordConstants";

export class UserActionsService {
  $auth: any;
  $state: any;
  jwt: any;
  usersService: UsersService;

  constructor(
    $auth: any,
    $state: any,
    jwtHelper: any,
    usersService: UsersService
  ) {
    "ngInject";

    this.$auth = $auth;
    this.$state = $state;
    this.jwt = jwtHelper;
    this.usersService = usersService;
  }

  login(loginModel: LoginModel) {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({
          type: USER_LOGIN_REQUEST,
        });

        const tokens: any = await self.usersService.login(loginModel);
        const userInfo = self.jwt.decodeToken(tokens.accessToken);

        dispatch({
          type: USER_LOGIN_SUCCESS,
          payload: userInfo,
        });

        localStorage.setItem("accessToken", tokens.accessToken);
        localStorage.setItem("refreshToken", tokens.refreshToken);

        console.log("successfully logged in");
        self.$state.go("app");
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

  loadUserInfo(userInfo) {
    return async function (dispatch) {
      dispatch({
        type: USER_LOGIN_SUCCESS,
        payload: userInfo,
      });
    };
  }

  logout(userId: string) {
    const self = this;
    return async function (dispatch) {
      localStorage.removeItem("accessToken");
      // TODO remove refresh token from db
      self.usersService.logout(userId);
      localStorage.removeItem("refreshToken");
      dispatch({
        type: USER_LOGOUT,
      });
      dispatch({
        type: RECORDS_RESET,
      });
      console.log("successfully logged out");
      self.$state.go("login");
    };
  }
}
