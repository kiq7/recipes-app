import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { IRecipe } from 'src/app/structure/interfaces';
import { RecipeService } from 'src/app/services';

// // TODO: replace this with real data from your application
// const EXAMPLE_DATA: IRecipe[] = [
//   {
//     id: '1',
//     name: 'Bolo de fuba',
//     calories: 23,
//     serves: 20,
//     ingredients: [
//       { id: '2', name: 'Queijo' },
//       { id: '4', name: 'Tomate' },
//     ],
//     directions: 'aeAEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE'
//   },
//   { id: '2', name: 'Bolo de fuba', calories: 23, serves: 20, ingredients: [{ id: '2', name: 'Queijo' }], directions: 'ae' },
//   { id: '3', name: 'Bolo de fuba', calories: 23, serves: 20, ingredients: [{ id: '2', name: 'Queijo' }], directions: 'ae' },
//   { id: '4', name: 'Bolo de fuba', calories: 23, serves: 20, ingredients: [{ id: '2', name: 'Queijo' }], directions: 'ae' },
//   { id: '5', name: 'Bolo de fuba', calories: 23, serves: 20, ingredients: [{ id: '2', name: 'Queijo' }], directions: 'ae' }
// ];

/**
 * Data source for the RecipesList view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class RecipesListDataSource extends DataSource<IRecipe> {
  data: IRecipe[];

  constructor(private paginator: MatPaginator, private sort: MatSort, private service: RecipeService) {
    super();

    this.service.get().subscribe(recipes => {
      this.data = recipes;
    });
  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<IRecipe[]> {
    // Combine everything that affects the rendered data into one update
    // stream for the data-table to consume.
    const dataMutations = [observableOf(this.data), this.paginator.page, this.sort.sortChange];

    // Set the paginator's length
    this.paginator.length = this.data.length;

    return merge(...dataMutations).pipe(
      map(() => {
        return this.getPagedData(this.getSortedData([...this.data]));
      })
    );
  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect() {}

  /**
   * Paginate the data (client-side). If you're using server-side pagination,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getPagedData(data: IRecipe[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  /**
   * Sort the data (client-side). If you're using server-side sorting,
   * this would be replaced by requesting the appropriate data from the server.
   */
  private getSortedData(data: IRecipe[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'name':
          return compare(a.name, b.name, isAsc);
        case 'id':
          return compare(+a.id, +b.id, isAsc);
        default:
          return 0;
      }
    });
  }
}

/** Simple sort comparator for example ID/Name columns (for client-side sorting). */
function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
