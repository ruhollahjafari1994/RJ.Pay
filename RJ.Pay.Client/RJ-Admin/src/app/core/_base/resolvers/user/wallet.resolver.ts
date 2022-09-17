import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Wallet } from 'src/app/data/models/wallet';
import { WalletService } from 'src/app/core/_services/panel/user/wallet.service';

@Injectable()
export class WalletResolver implements Resolve<Wallet[]> {
    constructor(private walletService: WalletService,
                private alertService: ToastrService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Wallet[]> {
        return this.walletService.getWallets().pipe(
            catchError(error => {
                this.alertService.error(error, 'خطا');
                return of(null);
            })
        );
    }
}
