﻿using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.DTOs.User;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.Models.Identity;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<BaseCommandResponse> UpdateUserPassword(string userId,PasswordChangeDto userDto); 
        Task<Employee> GetEmployeeByUserId(string userId);
        Task<UserDto> GetUserByTraineeId(string traineeId);
        Task<Employee> GetEmployee(string userId); 
        Task<PagedResult<UserDto>> GetUsers(QueryParams queryParams);
        Task<BaseCommandResponse> Save(string userId,List<CreateUserDto> user);
        Task<BaseCommandResponse> CreateUser(string userId,string traineeId, CreateTraineeBioDataGeneralInfoDto user);
        Task<BaseCommandResponse> Update(string userId,CreateUserDto user);
        Task<BaseCommandResponse> UpdateUserAsAServiceInstructor(string userId, CreateUserDto userDto, string branchId);
        Task<BaseCommandResponse> ReleseServiceInstructor(string userId);
        Task<BaseCommandResponse> UpdateUser(string userId, UpdateEmailPhoneDto user);
        Task<BaseCommandResponse> ResetPassword(string userId,CreateUserDto user);
        Task<UserDto> GetUserById(string id);
        Task<BaseCommandResponse> DeleteUser(string id);
        Task<BaseCommandResponse> DeleteBioDataUser(int traineeId);
        //Task<PagedResult<UserDto>> GetStudentUsers(QueryParams queryParams);
        Task<PagedResult<UserDto>> GetTeacherUsers(QueryParams queryParams);
        Task<PagedResult<UserDto>> GetTraineeList(QueryParams queryParams);
        Task<PagedResult<UserDto>> GetInstructorList(QueryParams queryParams);
        Task<object> GetEastablishmentUsers(int pageSize, int pageNumber, string SearchText); 

    }
}
