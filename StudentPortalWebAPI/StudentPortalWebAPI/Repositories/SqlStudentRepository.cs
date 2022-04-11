﻿using Microsoft.EntityFrameworkCore;
using StudentPortalWebAPI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalWebAPI.Repositories
{
    public class SqlStudentRepository : IStudentContext
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<Student> AddStudent(Student request)
        {
            var student = await context.AddAsync(request);
            await context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Student> Delete(Guid studentId)
        {
            var student = await GetStudent(studentId);

            if(student != null)
            {
                context.Student.Remove(student);
                await context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGenders()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            return await context.Student.Include(nameof(Address)).Include(nameof(Gender)).FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string imagePath)
        {
            var student = await this.GetStudent(studentId);
            if(student != null)
            {
                student.ProfileImageUrl = imagePath;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetStudent(studentId);
            if (existingStudent != null)
            {
                existingStudent.LastName = request.LastName;
                existingStudent.FirstName = request.FirstName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;

                await context.SaveChangesAsync();
                return existingStudent;
            }

            return null;
        }
    }
}
