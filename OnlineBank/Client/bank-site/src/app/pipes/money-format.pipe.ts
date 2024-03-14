import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'moneyFormat'
})
export class MoneyFormatPipe implements PipeTransform {
  transform(balance: number | null): string {
    if (balance == null) return '';
    const formattedBalance = balance.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ' ');
    return formattedBalance;
  }
}
