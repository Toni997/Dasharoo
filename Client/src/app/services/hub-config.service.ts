import { HubConnectionBuilder } from "@microsoft/signalr";

export class HubConfigService {
  hubConnectionBuilder: HubConnectionBuilder = new HubConnectionBuilder();

  constructor() {
    "ngInject";
    // this.connection.on("ReceiveMessage", (user, message) => {
    //   console.log(user, message);
    // });

    // hubConnection.start().then(() => {
    //   hubConnection.invoke("SendMessage", "Hello", "Brother");
    //   console.log(hubConnection);
    // });
  }

  connect() {
    return this.hubConnectionBuilder
      .withUrl("https://localhost:44350/myhub")
      .build();
  }
}
