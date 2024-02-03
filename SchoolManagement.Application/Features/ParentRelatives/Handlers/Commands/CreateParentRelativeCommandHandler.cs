using AutoMapper;
using SchoolManagement.Application.DTOs.ParentRelative.Validators;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Commands
{
    public class CreateParentRelativeCommandHandler : IRequestHandler<CreateParentRelativeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateParentRelativeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateParentRelativeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateParentRelativeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ParentRelativeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ParentRelative = _mapper.Map<ParentRelative>(request.ParentRelativeDto);

                ParentRelative = await _unitOfWork.Repository<ParentRelative>().Add(ParentRelative);
                //try
                //{
                //    await _unitOfWork.Save();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex);
                //}
                await _unitOfWork.Save();
                
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ParentRelative.ParentRelativeId;
            }

            return response;
        }
    }
}
