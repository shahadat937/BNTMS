using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DefenseTypes.Handlers.Commands
{
    public class DeleteDefenseTypeCommandHandler : IRequestHandler<DeleteDefenseTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDefenseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDefenseTypeCommand request, CancellationToken cancellationToken)
        {
            var DefenseType = await _unitOfWork.Repository<DefenseType>().Get(request.DefenseTypeId);

            if (DefenseType == null)
                throw new NotFoundException(nameof(DefenseType), request.DefenseTypeId);

            await _unitOfWork.Repository<DefenseType>().Delete(DefenseType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
