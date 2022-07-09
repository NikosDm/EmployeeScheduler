import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css'],
})
export class ConfirmModalComponent implements OnInit {
  @Input() deleteSelectedRecord = new EventEmitter();
  title: string;
  closeBtnName: string;
  confirmButtonName: string = 'Delete';
  content: string;

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {}

  onDeleteRecord() {
    this.deleteSelectedRecord.emit();
    this.bsModalRef.hide();
  }
}
