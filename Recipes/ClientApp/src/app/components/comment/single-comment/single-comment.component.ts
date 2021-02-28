import { Component, Input, OnInit } from '@angular/core';
import ICommentDetails from '../../shared/models/comments/ICommentDetails';

@Component({
  selector: 'app-single-comment',
  templateUrl: './single-comment.component.html',
  styleUrls: ['./single-comment.component.css']
})
export class SingleCommentComponent implements OnInit {
  @Input() comment: ICommentDetails;

  constructor() { }

  ngOnInit() {
  }
}
