import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student/student.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(private studentServices : StudentService) { }

  ngOnInit(): void { }
}
