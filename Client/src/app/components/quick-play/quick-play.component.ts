import { ReduxService } from "app/services/redux.service";
import { UsersService } from "app/services/users.service";
import "./quick-play.component.scss";

export class QuickPlayController {
  $scope: any;
  usersService: UsersService;
  reduxService: ReduxService;
  dispatch: any;

  constructor(
    $scope: any,
    usersService: UsersService,
    reduxService: ReduxService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.usersService = usersService;
    this.$scope.users = null;
    this.reduxService = reduxService;
  }

  async $onInit() {
    this.$scope.users = await this.usersService.getAll();
    this.$scope.$apply();
    this.dispatch = this.reduxService.dispatch();
  }
}

export const QuickPlayComponent: ng.IComponentOptions = {
  template: require("./quick-play.component.html").default,
  controller: QuickPlayController,
};
