import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
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

  newStudent:boolean = true;
  header = '';

  genderList: gender[] = [];
  constructor(private studentService: StudentService,
    private route:ActivatedRoute,
    private readonly genderService: GenderService,
    private snackBar: MatSnackBar,
    private router: Router
    ) { }

  ngOnInit(): void
  {
    // if not existing the
    // -> new create student

    this.route.paramMap.subscribe(
      (params) => {
        this.studentId = params.get('id')

        if(this.studentId)
        {
          if(this.studentId.toLowerCase() == 'add'.toLowerCase())
          {
            this.newStudent = true;
            this.header = 'Add New Student';
          }
          else {
            this.newStudent = false;
            this.header = 'Edit Student';
            //body
            if(this.studentId)
            {
              this.studentService.getStudent(this.studentId)
              .subscribe(
                (successResponse) =>{
                  this.studentData = successResponse;
                }
              )
            }
      }}})
    this.genderService.getGenders().subscribe(
      (successResponse) => {
        this.genderList = successResponse;
      }
    )
  }

  onDelete() : void
  {
    this.studentService.deleteStudent(this.studentData.id).subscribe(
      (successResponse) => {
        console.log(this.studentData.id);
        this.snackBar.open('Student Delete Successfully',undefined, {
          duration: 2000
        });
        setTimeout(() => {
          this.router.navigateByUrl('student');
        }, 3000);
      }
    )
  }

  onAdd(): void
  {
    this.studentService.addStudent(this.studentData).subscribe(
      (successResponse) => {
        console.log(successResponse);

        this.snackBar.open("Student Added Successfully",undefined,{
          duration:2000
        })

        setTimeout(() => {
          this.router.navigateByUrl(`Student/${successResponse.id}`);
        }, 3000);
      }
    )
  }
}
