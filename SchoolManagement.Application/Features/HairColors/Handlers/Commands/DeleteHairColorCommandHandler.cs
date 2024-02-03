using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.HairColors.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HairColors.Handlers.Commands
{
    public class DeleteHairColorCommandHandler : IRequestHandler<DeleteHairColorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteHairColorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHairColorCommand request, CancellationToken cancellationToken)
        {
            var HairColor = await _unitOfWork.Repository<HairColor>().Get(request.HairColorId);

            if (HairColor == null)
                throw new NotFoundException(nameof(HairColor), request.HairColorId);

            await _unitOfWork.Repository<HairColor>().Delete(HairColor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
