using MediatR;
using SchoolManagement.Application.DTOs.BnaBatch;

namespace SchoolManagement.Application.Features.BnaBatches.Requests.Commands
{
    public class UpdateBnaBatchCommand : IRequest<Unit>
    {
        public BnaBatchDto BnaBatchDto { get; set; }
    }
} 
