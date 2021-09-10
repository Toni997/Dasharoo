import { GenresService } from "app/services/genres.service";
import "./search-view.component.scss";

export class SearchViewController {
  genresService: GenresService;
  $scope: any;
  genresStructured: any[] = [];
  divElement: HTMLElement;
  $document: ng.IDocumentService;

  constructor(
    $scope: any,
    genresService: GenresService,
    $document: ng.IDocumentService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.$document = $document;
    this.$scope.genres = null;
    this.genresService = genresService;
    this.$scope.genresStructured = [];

    this.divElement = this.$document[0].createElement("div");
    this.divElement.classList.add("genres-tree");
  }

  async $onInit() {
    this.$scope.genres = await this.genresService.getAll();
    // this.getGenres();
    const exploreGenres: HTMLDivElement =
      this.$document[0].querySelector("#explore-genres");
    exploreGenres.appendChild(this.divElement);
    this.getGenresInList();
    this.$scope.$apply();
    console.log(exploreGenres);
    // console.log("s", this.$scope.genresStructured);
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
      a.classList.add("genre-link");

      let li: HTMLElement = this.$document[0].createElement("li");
      a.innerText = genre.name;
      li.style.marginLeft = marginLeft.toString() + "px";

      li.appendChild(a);
      ul.appendChild(li);
      this.getGenresInList(li, genre.id, marginLeft + 10);
    }
  }
}

export const SearchViewComponent: ng.IComponentOptions = {
  template: require("./search-view.component.html").default,
  controller: SearchViewController,
};
