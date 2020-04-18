import {Component, OnInit} from '@angular/core';
import {PushNotificationService} from "../../../../core/service/push-notification.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AddEventModalComponent} from "../../components/add-event-modal/add-event-modal.component";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(private pushNotificationService: PushNotificationService,
              private modalService: NgbModal) {
  }

  ngOnInit(): void {
      if(!this.pushNotificationService.isSubscribeInit()) {
        this.pushNotificationService.init();
      }
  }

  openAddEventModal() {
    this.modalService.open(AddEventModalComponent);
  }
}
