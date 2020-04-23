import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TaskService} from "../../../../../data/service/task.service";
import {Task} from "../../../../../data/schema/task";
import {BehaviorSubject} from "rxjs";
import {ToppyControl} from "toppy";

@Component({
  selector: 'app-task-popover',
  templateUrl: './task-popover.component.html',
  styleUrls: ['./task-popover.component.scss']
})
export class TaskPopoverComponent implements OnInit {

  @Input() taskId: string;
  @Input() currentPopover: ToppyControl;
  @Output() onToggleTask: EventEmitter<boolean>;

  task: Task = {
    title: 'Loading...'
  };

  taskSubject: BehaviorSubject<Task>;

  //taskService: TaskService


  constructor(private taskService: TaskService) {
    this.taskSubject = new BehaviorSubject<Task>(this.task);
    this.onToggleTask = new EventEmitter<boolean>();
  }

  ngOnInit(): void {

    this.taskService.getTaskById(this.taskId)
      .subscribe(value => {
        this.task = value;
        this.taskSubject.next(this.task);
      });
  }

  close() {
    this.currentPopover.close();
  }

  checkTaskDone() {
    this.taskService.checkTask(this.task.id)
      .subscribe(value => {
        this.task.isDone = true;
        this.onToggleTask.emit(true);
      });
  }

  uncheckTaskDone() {
    this.taskService.uncheckTask(this.task.id)
      .subscribe(value => {
        this.task.isDone = false;
        this.onToggleTask.emit(false);
      });
  }
}
