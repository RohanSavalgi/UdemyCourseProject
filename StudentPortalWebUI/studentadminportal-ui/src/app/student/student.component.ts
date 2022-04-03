import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { student } from '../models/ui-models/student.model';
import { StudentService } from './student.service';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  students: student[] = [];
  displayedColumns: string[] = ['firstName', 'lastName','dataOfBirth','email','mobile','gender'];
  dataSource: MatTableDataSource<student> = new MatTableDataSource<student>();

  @ViewChild(MatPaginator) MatPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;

  constructor(private studentservice : StudentService) { }

  ngOnInit(): void {
    this.studentservice.getStudent().subscribe(
        (successRespose) => {
          this.students = successRespose;
          console.log(successRespose);
          this.dataSource = new MatTableDataSource<student>(this.students);

          if(this.matSort)
          {
            this.dataSource.sort = this.matSort;

          }
          if(this.MatPaginator)
          {
            this.dataSource.paginator = this.MatPaginator;
          }


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
