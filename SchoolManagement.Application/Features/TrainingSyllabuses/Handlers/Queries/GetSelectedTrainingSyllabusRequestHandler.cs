using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Queries
{
    public class GetSelectedTrainingSyllabusRequestHandler : IRequestHandler<GetSelectedTrainingSyllabusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TrainingSyllabus> _TrainingSyllabusRepository;


        public GetSelectedTrainingSyllabusRequestHandler(ISchoolManagementRepository<TrainingSyllabus> TrainingSyllabusRepository)
        {
            _TrainingSyllabusRepository = TrainingSyllabusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTrainingSyllabusRequest request, CancellationToken cancellationToken)
        {
            ICollection<TrainingSyllabus> codeValues = await _TrainingSyllabusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course,
                Value = x.TrainingSyllabusId
            }).ToList();
            return selectModels;
        }
    }
}
