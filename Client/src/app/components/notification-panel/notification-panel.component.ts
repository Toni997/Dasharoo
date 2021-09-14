import { HubConnection } from "@microsoft/signalr";
import { StateService } from "@uirouter/angularjs";
import { IScope } from "angular";
import { HubConfigService } from "app/services/hub-config.service";
import "./notification-panel.component.scss";

export class NotificationPanelController {
  hubConfigService: HubConfigService;
  connection: HubConnection;
  notifications: [] = [];
  newGenresAdded: boolean = false;
  $scope: IScope;
  $state: StateService;

  constructor(
    $scope: IScope,
    $state: StateService,
    hubConfigService: HubConfigService
  ) {
    "ngInject";

    this.hubConfigService = hubConfigService;
    this.$scope = $scope;
    this.$state = $state;
  }

  async $onInit() {
    this.connection = this.hubConfigService.connect();

    await this.connection.start();
    this.connection.invoke("NotifyOnConnect", "Connected");

    this.connection.on("ReceiveNotification", (user, message) => {
      console.log(user, message);
    });

    this.connection.on("GenreNotification", (message) => {
      this.newGenresAdded = true;
      this.$scope.$apply();
      console.log(message);
    });

    this.connection.on("Connected", (message) => {
      console.log(message, "with id:", this.connection.connectionId);
    });
  }

  reload() {
    this.$state.reload();
    this.newGenresAdded = false;
  }
}

export const NotificationPanelComponent: ng.IComponentOptions = {
  template: require("./notification-panel.component.html").default,
  controller: NotificationPanelController,
};
