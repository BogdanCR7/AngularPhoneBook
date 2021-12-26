import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../models/contacts';

@Pipe({
  name: 'myfilter',
  pure: false,
})
export class MyFilterPipe implements PipeTransform {
  transform(items: Contact[], filter: string, category: string): any {
    console.log(category);

    if (category != undefined && category != '') {
      console.log(category);

      items = items.filter((item) => {
        return item.category === category;
      });
    }

    if (!items || !filter) {
      return items;
    }
    return items.filter(
      (item) => item.name.toLowerCase().indexOf(filter.toLowerCase()) !== -1
    );
  }
}
