using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Commands
{
    public class ChangeDocStatusCommandHandler : IRequestHandler<ChangeDocStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeDocStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeDocStatusCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseOtherDoc = await _unitOfWork.Repository<ForeignCourseOtherDoc>().Get(request.ForeignCourseOtherDocId);

            if(request.FieldName == "passport")
            {
                ForeignCourseOtherDoc.Passport = request.Status;
            }else if (request.FieldName == "dgfi")
            {
                ForeignCourseOtherDoc.DgfiBreafing = request.Status;
            }


            if (ForeignCourseOtherDoc == null)
                throw new NotFoundException(nameof(ForeignCourseOtherDoc), request.ForeignCourseOtherDocId);

            

            await _unitOfWork.Repository<ForeignCourseOtherDoc>().Update(ForeignCourseOtherDoc);
            await _unitOfWork.Save();

            

            return Unit.Value;
        }
    }
}
