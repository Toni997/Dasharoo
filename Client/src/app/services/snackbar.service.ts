export class SnackbarService {
  private $rootScope: ng.IRootScopeService;
  private $compile: ng.ICompileService;
  private $document: ng.IDocumentService;
  private $timeout: ng.ITimeoutService;

  constructor(
    $rootScope: ng.IRootScopeService,
    $compile: ng.ICompileService,
    $document: ng.IDocumentService,
    $timeout: ng.ITimeoutService
  ) {
    "ngInject";

    this.$rootScope = $rootScope;
    this.$compile = $compile;
    this.$document = $document;
    this.$timeout = $timeout;
  }

  open(message: string, timespan: number = 2000) {
    const scope = this.$rootScope.$new();
    const cmpl = this.$compile(`<snackbar message="${message}"></snackbar>`)(
      scope
    );
    const snackbar: HTMLElement = cmpl[0];
    snackbar.classList.add("error");
    this.$document.find("body")[0].append(snackbar);
    this.$timeout(() => {
      snackbar.remove();
    }, timespan);
  }
}
