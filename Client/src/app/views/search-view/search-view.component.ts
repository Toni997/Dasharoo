import { GenresService } from "app/services/genres.service";
import "./search-view.component.scss";

export class SearchViewController {
  genresService: GenresService;
  $scope: any;
  genresStructured: any[] = [];
  array1;
  array2;

  constructor($scope: any, genresService: GenresService) {
    "ngInject";

    this.$scope = $scope;
    this.$scope.genres = null;
    this.genresService = genresService;
    this.$scope.genresStructured = [];
  }

  async $onInit() {
    this.$scope.genres = await this.genresService.getAll();
    this.getGenres();
    this.$scope.$apply();
    console.log("s", this.$scope.genresStructured);
  }

  getGenres(
    currentArray = this.$scope.genresStructured,
    currentParentId = null
  ) {
    currentArray.push(
      ...this.$scope.genres
        .filter((genre) => genre.parentGenreId === currentParentId)
        .map((genre) => {
          return { genre, children: [] };
        })
    );
    if (currentArray.length === 0) return;

    for (let child of currentArray)
      this.getGenres(child.children, child.genre.id);
  }
}

export const SearchViewComponent: ng.IComponentOptions = {
  template: require("./search-view.component.html").default,
  controller: SearchViewController,
};
