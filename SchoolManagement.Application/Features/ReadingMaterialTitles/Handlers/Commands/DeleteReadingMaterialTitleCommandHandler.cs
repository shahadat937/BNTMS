using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Commands
{
    public class DeleteReadingMaterialTitleCommandHandler : IRequestHandler<DeleteReadingMaterialTitleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReadingMaterialTitleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReadingMaterialTitleCommand request, CancellationToken cancellationToken)
        {
            var ReadingMaterialTitle = await _unitOfWork.Repository<ReadingMaterialTitle>().Get(request.ReadingMaterialTitleId);

            if (ReadingMaterialTitle == null)
                throw new NotFoundException(nameof(ReadingMaterialTitle), request.ReadingMaterialTitleId);

            await _unitOfWork.Repository<ReadingMaterialTitle>().Delete(ReadingMaterialTitle);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
