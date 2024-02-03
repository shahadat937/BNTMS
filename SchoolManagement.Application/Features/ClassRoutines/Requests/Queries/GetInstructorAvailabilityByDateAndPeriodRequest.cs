using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetInstructorAvailabilityByDateAndPeriodRequest : IRequest<List<ClassRoutineDto>>
    {
        public int TraineeId { get; set; }
        public int ClassPeriodId { get; set; }   
        public DateTime Date { get; set; }
    }
}

 