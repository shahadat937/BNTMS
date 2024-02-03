using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BudgetCodess.Requests.Queries
{
    public class GetSelectedBudgetCodeByParametersFromClassRoutineRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; } 
    }
}

   