using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Commands
{
    public class UpdateForeignCourseOtherDocCommandHandler : IRequestHandler<UpdateForeignCourseOtherDocCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForeignCourseOtherDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForeignCourseOtherDocCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseOtherDocs = request.ForeignCourseOtherDocListDto;

            var ForeignCourseOtherDocList = ForeignCourseOtherDocs.traineeListForm.Select(x => new ForeignCourseOtherDoc()
            {
                ForeignCourseOtherDocId = x.ForeignCourseOtherDocId.Value,
                CourseDurationId = ForeignCourseOtherDocs.CourseDurationId,
                CourseNameId = x.CourseNameId,
                TraineeNominationId = x.TraineeNominationId,
                TraineeId = x.TraineeId,
                Ticket = x.Ticket,
                Visa = x.Visa,
                Passport = x.Passport, 
                CovidTest = x.CovidTest,
                MedicalTest = ForeignCourseOtherDocs.MedicalTest,
                DgfiBreafing =x.DgfiBreafing,
                DniBreafing =x.DniBreafing,
                EmbassiBreafing =x.EmbassiBreafing,
                FinancialSanction =x.FinancialSanction,
                ExBdLeave = x.ExBdLeave,
                FamilyGo = x.FamilyGo,
                MedicalDocument =x.MedicalDocument,
                Remark = x.Remark,
                MenuPosition = x.MenuPosition,
                CreatedBy = "",
                DateCreated = DateTime.Now,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedDate = DateTime.Now,
                IsActive = x.IsActive,
                Status = x.Status
            });

            foreach (var item in ForeignCourseOtherDocList)
            {
                await _unitOfWork.Repository<ForeignCourseOtherDoc>().Update(item);
                await _unitOfWork.Save();
            }
            return Unit.Value;
        }
    }
}
