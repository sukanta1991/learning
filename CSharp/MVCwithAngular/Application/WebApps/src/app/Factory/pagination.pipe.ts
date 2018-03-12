import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'pagination'
})

export class PaginationPipe implements PipeTransform {
    transform(item: any[], counter:any): any[] {
        return item.slice(counter * 3, counter *3 + 3);
    }
}
