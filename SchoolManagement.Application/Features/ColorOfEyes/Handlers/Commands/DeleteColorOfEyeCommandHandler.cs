using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Commands
{
    public class DeleteColorOfEyeCommandHandler : IRequestHandler<DeleteColorOfEyeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteColorOfEyeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteColorOfEyeCommand request, CancellationToken cancellationToken)
        {
            var ColorOfEye = await _unitOfWork.Repository<ColorOfEye>().Get(request.ColorOfEyesId);

            if (ColorOfEye == null)
                throw new NotFoundException(nameof(ColorOfEye), request.ColorOfEyesId);

            await _unitOfWork.Repository<ColorOfEye>().Delete(ColorOfEye);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
