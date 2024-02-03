using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTestType;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands
{
    public class UpdateBnaClassTestTypeCommand: IRequest<Unit>
    {
        public BnaClassTestTypeDto BnaClassTestTypeDto { get; set; }
    }
}
 