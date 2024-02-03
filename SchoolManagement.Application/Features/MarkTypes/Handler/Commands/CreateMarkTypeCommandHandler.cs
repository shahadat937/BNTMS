using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkType.Validators;
using SchoolManagement.Application.Features.MarkTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkTypes.Handler.Queries
{
    public class CreateMarkTypeCommandHandler : IRequestHandler<CreateMarkTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMarkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMarkTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMarkTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MarkTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MarkType = _mapper.Map<MarkType>(request.MarkTypeDto);

                MarkType.PolicyStatus = 0;
                MarkType = await _unitOfWork.Repository<MarkType>().Add(MarkType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MarkType.MarkTypeId;
            }

            return response;
        }
    }
}
