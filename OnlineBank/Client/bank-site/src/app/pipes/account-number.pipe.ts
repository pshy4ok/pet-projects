import {Pipe, PipeTransform} from "@angular/core";

@Pipe({
  name: 'accountNumberFormat'
})
export class AccountNumberPipe implements PipeTransform {
  transform(accountNumber: number | null): string {
    if (!accountNumber) return '';
    const accountNumberString = accountNumber.toString();
    const groups = accountNumberString.match(/.{1,4}/g);
    if (!groups) return '';
    return groups.join(' ');
  }
}
