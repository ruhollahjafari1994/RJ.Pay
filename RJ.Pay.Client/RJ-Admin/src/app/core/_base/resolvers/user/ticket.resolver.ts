import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TicketService } from 'src/app/core/_services/panel/user/ticket.service';
import { Ticket } from 'src/app/data/models/ticket';

@Injectable()
export class TicketResolver implements Resolve<Ticket[]> {
    constructor(private ticketService: TicketService, private router: Router,
                private alertService: ToastrService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Ticket[]> {
        return this.ticketService.getTickets( 0).pipe(
            catchError(error => {
                this.alertService.error(error, 'خطا');
                return of(null);
            })
        );
    }
}
