import { StateParams, StateService } from "@uirouter/core";
import { RecordsService } from "app/services/records.service";
import { GenresService } from "app/services/genres.service";
import "./search-view.component.scss";
import { PlaylistsService } from "app/services/playlists.service";
import AddRecordToPlaylist from "app/data/addRecordToPlaylist";

interface SearchResults {
  artists: [];
  playlists: [];
  records: [];
}

export class SearchViewController {
  playlistsService: PlaylistsService;
  recordsService: RecordsService;
  genresService: GenresService;
  $scope: any;
  genresStructured: any[] = [];
  divElement: HTMLElement;
  $document: ng.IDocumentService;
  dinputText: string;
  $state: StateService;
  $stateParams: StateParams;
  searchResults: SearchResults = {
    artists: [],
    playlists: [],
    records: [],
  };

  constructor(
    $document: ng.IDocumentService,
    $scope: any,
    $state: StateService,
    $stateParams: StateParams,
    playlistsService: PlaylistsService,
    recordsService: RecordsService,
    genresService: GenresService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.$document = $document;
    this.$state = $state;
    this.$stateParams = $stateParams;

    this.$scope.genres = null;
    this.playlistsService = playlistsService;
    this.recordsService = recordsService;
    this.genresService = genresService;
    this.$scope.genresStructured = [];

    this.divElement = this.$document[0].createElement("div");
    this.divElement.classList.add("genres-tree");
  }

  async $onInit() {
    if (!this.$stateParams.q) {
      this.$scope.genres = await this.genresService.getAll();
      const exploreGenres: HTMLDivElement =
        this.$document[0].querySelector("#explore-genres");
      exploreGenres.appendChild(this.divElement);
      this.getGenresInList();
      this.$scope.$apply();
    } else {
      this.$scope.$watch("SC.$stateParams.q", async () => {
        console.log("changed");
        this.searchResults.records = (await this.recordsService.getAllByKeyword(
          this.$stateParams.q
        )) as [];
        this.$scope.$apply();
      });
    }
  }

  // getGenres(
  //   currentArray = this.$scope.genresStructured,
  //   currentParentId = null
  // ) {
  //   currentArray.push(
  //     ...this.$scope.genres
  //       .filter((genre) => genre.parentGenreId === currentParentId)
  //       .map((genre) => {
  //         return { genre, children: [] };
  //       })
  //   );
  //   if (currentArray.length === 0) return;

  //   for (let child of currentArray)
  //     this.getGenres(child.children, child.genre.id);
  // }

  getGenresInList(
    currentElement = this.divElement,
    currentParentId = null,
    marginLeft = 0
  ) {
    let genreChildren = this.$scope.genres.filter(
      (genre) => genre.parentGenreId === currentParentId
    );

    if (genreChildren.length === 0) return;

    let ul: HTMLElement = this.$document[0].createElement("ul");
    currentElement.appendChild(ul);

    for (let genre of genreChildren) {
      let a: HTMLElement = this.$document[0].createElement("a");
      a.setAttribute("href", genre.id);
      a.classList.add("router-link");

      let li: HTMLElement = this.$document[0].createElement("li");
      a.innerText = genre.name;
      li.style.marginLeft = marginLeft.toString() + "px";

      li.appendChild(a);
      ul.appendChild(li);
      this.getGenresInList(li, genre.id, marginLeft + 10);
    }
  }

  async onSubmit() {
    this.$state.go("search", { q: this.dinputText });
  }

  addRecordToPlaylist(recordId: number) {
    const playlistId: number = this.$stateParams.add_to;
    if (!playlistId) return;
    console.log(recordId);
    const addRecordToPlaylist: AddRecordToPlaylist = {
      playlistId,
      recordId,
    };
    this.playlistsService
      .addToPlaylist(addRecordToPlaylist)
      .then(() => {
        console.log("success adding to playlist");
      })
      .catch(() => {
        console.log("error adding to playlist");
      });
  }
}

export const SearchViewComponent: ng.IComponentOptions = {
  template: require("./search-view.component.html").default,
  controller: SearchViewController,
  controllerAs: "SC",
};
