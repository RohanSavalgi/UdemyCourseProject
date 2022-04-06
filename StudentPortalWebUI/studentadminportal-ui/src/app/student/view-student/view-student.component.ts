import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { gender } from 'src/app/models/api-models/gender.model';
import { student } from 'src/app/models/api-models/student.model';
import { GenderService } from 'src/app/services/gender.service';
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
  genderList: gender[] = [];
  constructor(private studentService: StudentService,
    private route:ActivatedRoute,
    private readonly genderService: GenderService,
    ) { }

  ngOnInit(): void
  {
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

    this.genderService.getGenders().subscribe(
      (successResponse) => {
        this.genderList = successResponse;
      }
    )
  }
}
