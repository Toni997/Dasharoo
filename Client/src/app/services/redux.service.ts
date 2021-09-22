import { RecordActionsService } from "app/actions/record-actions.service";
import { RecordsService } from "app/records.service";
import LoginModel from "app/data/login.model";
import { UserActionsService } from "app/actions/user-actions.service";

export class ReduxService {
  redux: any;
  recordsService: RecordsService;
  recordActions: RecordActionsService;
  userActions: UserActionsService;
  isLoggedIn: boolean = false;

  constructor(
    $ngRedux: any,
    recordsService: RecordsService,
    recordActionsService: RecordActionsService,
    userActionsService: UserActionsService
  ) {
    "ngInject";
    this.redux = $ngRedux;
    this.recordsService = recordsService;
    this.recordActions = recordActionsService;
    this.userActions = userActionsService;

    this.redux.subscribe(() => {
      if (this.getCurrentUser()) this.isLoggedIn = true;
      else this.isLoggedIn = false;
    });
  }

  dispatch() {
    const self = this;
    return {
      addToQueue(id: number) {
        self.redux.dispatch(self.recordActions.addToQueue(id));
      },
      login(loginModel: LoginModel) {
        self.redux.dispatch(self.userActions.login(loginModel));
      },
      logout() {
        const currentUserId = self.getCurrentUser().id;
        self.redux.dispatch(self.userActions.logout(currentUserId));
      },
      loadUserInfo(userInfo: any) {
        self.redux.dispatch(self.userActions.loadUserInfo(userInfo));
      },
    };
  }

  getCurrentUser() {
    return this.redux.getState().userDetails.user;
  }

  getRecords() {
    return this.redux.getState().records;
  }
}
