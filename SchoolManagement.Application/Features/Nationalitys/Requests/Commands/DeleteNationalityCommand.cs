using MediatR;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Commands
{
    public class DeleteNationalityCommand : IRequest
    {
        public int NationalityId { get; set; }
    }
}
