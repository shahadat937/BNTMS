using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesters.Handlers.Commands
{
    public class DeleteBnaSemesterCommandHandler: IRequestHandler<DeleteBnaSemesterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaSemesterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaSemesterCommand request, CancellationToken cancellationToken)
        {
            var BnaSemester = await _unitOfWork.Repository<BnaSemester>().Get(request.BnaSemesterId);

            if (BnaSemester == null)
                throw new NotFoundException(nameof(BnaSemester), request.BnaSemesterId);

            await _unitOfWork.Repository<BnaSemester>().Delete(BnaSemester);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 