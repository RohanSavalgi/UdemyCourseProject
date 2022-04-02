import { Component, OnInit } from '@angular/core';
import { StudentService } from './student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(private studentservice : StudentService) { }

  ngOnInit(): void {
    this.studentservice.getStudent().subscribe(
        (successRespose) => {
          console.log(successRespose)
        },
        (errorRespose) => {
          console.log(errorRespose)
        }
    )
  }

  click() : void {
    console.log("button click")
  }
}
