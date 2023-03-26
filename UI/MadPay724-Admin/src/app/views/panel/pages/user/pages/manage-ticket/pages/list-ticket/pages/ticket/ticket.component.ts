import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { Ticket } from 'src/app/data/models/ticket';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  @Input() ticket: Ticket;
  @Input() ticketId: string;
  @Output() selectedTicketId = new EventEmitter<string>();
  constructor(private router: Router, private title: Title) { }

  ngOnInit() {
  }
  onClick(ticketId: string) {

    this.selectedTicketId.emit(ticketId);
    this.router.navigate(['panel/user/tickets/overview', ticketId]);
  }
}
