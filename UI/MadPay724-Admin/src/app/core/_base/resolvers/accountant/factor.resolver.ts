import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FactorService } from 'src/app/core/_services/panel/accountant/factor.service';
import { Factor } from 'src/app/data/models/accountant/factor';
import { FactorDetail } from 'src/app/data/models/accountant/factorDetail';


@Injectable()
export class FactorResolver implements Resolve<FactorDetail> {
    constructor(private factorService: FactorService,
                private alertService: ToastrService) { }
    resolve(route: ActivatedRouteSnapshot): Observable<FactorDetail> {
        return this.factorService.getFactor(route.params['factorId']).pipe(
            catchError(error => {
                this.alertService.error(error, 'خطا');
                return of(null);
            })
        );
    }
}
