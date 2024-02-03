using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum.Validators;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Commands
{
    public class CreateBnaSubjectCurriculumCommandHandler : IRequestHandler<CreateBnaSubjectCurriculumCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaSubjectCurriculumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaSubjectCurriculumCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaSubjectCurriculumDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaSubjectCurriculumDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaSubjectCurriculum = _mapper.Map<BnaSubjectCurriculum>(request.BnaSubjectCurriculumDto);

                BnaSubjectCurriculum = await _unitOfWork.Repository<BnaSubjectCurriculum>().Add(BnaSubjectCurriculum);
               
                await _unitOfWork.Save();
                
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaSubjectCurriculum.BnaSubjectCurriculumId;
            }

            return response;
        }
    }
}
