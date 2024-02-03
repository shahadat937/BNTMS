﻿using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Districts.Handlers.Queries
{
    public class GetSelectedDistrictRequestHandler : IRequestHandler<GetSelectedDistrictRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<District> _DistrictRepository;


        public GetSelectedDistrictRequestHandler(ISchoolManagementRepository<District> DistrictRepository)
        {
            _DistrictRepository = DistrictRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDistrictRequest request, CancellationToken cancellationToken)
        {
            ICollection<District> codeValues = await _DistrictRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DistrictName,
                Value = x.DistrictId
            }).ToList();
            return selectModels;
        }
    }
}
