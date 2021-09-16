import QueueAddType from "app/queueAddType.enum";
import { RecordActionsService } from "app/actions/record-actions.service";
import { RecordsService } from "app/records.service";
import LoginModel from "app/data/login.model";
import { UserActionsService } from "app/actions/user-actions.service";

export class ReduxService {
  redux: any;
  recordsService: RecordsService;
  recordActions: RecordActionsService;
  userActions: UserActionsService;

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
  }

  dispatch() {
    const self = this;
    return {
      addToQueue(id: number, type: QueueAddType = null) {
        self.redux.dispatch(self.recordActions.addToQueue(id, type));
      },
      login(loginModel: LoginModel) {
        self.redux.dispatch(self.userActions.login(loginModel));
      },
      logout() {
        self.redux.dispatch(self.userActions.logout());
      },
    };
  }
}
