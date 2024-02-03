using AutoMapper;
using SchoolManagement.Application.DTOs.Bulletin.Validators;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class CreateBulletinCommandHandler : IRequestHandler<CreateBulletinCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBulletinCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBulletinDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BulletinDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Bulletin = _mapper.Map<Bulletin>(request.BulletinDto);

                Bulletin = await _unitOfWork.Repository<Bulletin>().Add(Bulletin);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Bulletin.BulletinId;
            }

            return response;
        }
    }
}
