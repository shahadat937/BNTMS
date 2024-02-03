using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTestType.Validators;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Commands
{
    public class CreateBnaClassTestTypeCommandHandler: IRequestHandler<CreateBnaClassTestTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassTestTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassTestTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassTestTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassTestTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassTestType = _mapper.Map<BnaClassTestType>(request.BnaClassTestTypeDto);

                BnaClassTestType = await _unitOfWork.Repository<BnaClassTestType>().Add(BnaClassTestType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassTestType.BnaClassTestTypeId;
            }

            return response;
        }
    }
}
