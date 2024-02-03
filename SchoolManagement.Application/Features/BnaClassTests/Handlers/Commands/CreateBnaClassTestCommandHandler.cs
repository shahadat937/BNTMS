using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTest.Validators;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTests.Handlers.Commands
{
    public class CreateBnaClassTestCommandHandler: IRequestHandler<CreateBnaClassTestCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassTestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassTestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassTestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassTest = _mapper.Map<BnaClassTest>(request.BnaClassTestDto);

                BnaClassTest = await _unitOfWork.Repository<BnaClassTest>().Add(BnaClassTest);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassTest.BnaClassTestId;
            }

            return response;
        }
    }
}
