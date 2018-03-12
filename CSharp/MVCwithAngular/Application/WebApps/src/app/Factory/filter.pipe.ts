import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name:'filter'
})

export class FilterPipe implements PipeTransform {
    transform(item: any[], args?: string): any[] {
        if (!item) return [];
        if (!args) return item;
        console.log(item);
        args = args.toLowerCase();
        return item.filter(x => {
            return x.bookName.toLowerCase().includes(args);
        });
    }
}
