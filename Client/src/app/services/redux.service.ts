import { RecordActionsService } from "app/record-actions.service";
import { RecordsService } from "app/records.service";

export class ReduxService {
  redux: any;
  recordsService: RecordsService;
  recordActions: RecordActionsService;

  constructor(
    $ngRedux: any,
    recordsService: RecordsService,
    recordActionsService: RecordActionsService
  ) {
    "ngInject";
    this.redux = $ngRedux;
    this.recordsService = recordsService;
    this.recordActions = recordActionsService;
  }

  dispatch() {
    const self = this;
    return {
      addAllRecords() {
        self.redux.dispatch(self.recordActions.listProducts());
      },
    };
  }
}
