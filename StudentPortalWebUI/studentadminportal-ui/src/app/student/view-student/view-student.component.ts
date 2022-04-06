import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { student } from 'src/app/models/api-models/student.model';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.css']
})
export class ViewStudentComponent implements OnInit {

  studentId : string | null | undefined;
  studentData: student = {
    id: '',
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    email:'',
    mobile: 0,
    profileImageUrl: '',
    genderId: '',
    gender: {
      id: '',
    description: ''
    },
    address: {
      id: '',
      postalAddress: '',
      physicalAddress: '',
    }
  }

  constructor(private studentService: StudentService,
    private route:ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.studentId = params.get('id')

        if(this.studentId)
        {
          this.studentService.getStudent(this.studentId)
          .subscribe(
            (successResponse) =>{
              this.studentData = successResponse;
            }
          )
        }
      }
    )
  }
}
