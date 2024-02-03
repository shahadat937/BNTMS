using AutoMapper;
using SchoolManagement.Application.DTOs.TraineePicture;
using SchoolManagement.Application.Features.TraineePictures.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineePictures.Handlers.Queries
{
    public class GetTraineePictureListRequestHandler : IRequestHandler<GetTraineePictureListRequest, PagedResult<TraineePictureDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineePicture> _TraineePictureRepository;

        private readonly IMapper _mapper;

        public GetTraineePictureListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineePicture> TraineePictureRepository, IMapper mapper)
        {
            _TraineePictureRepository = TraineePictureRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineePictureDto>> Handle(GetTraineePictureListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineePicture> TraineePictures = _TraineePictureRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = TraineePictures.Count();
            TraineePictures = TraineePictures.OrderByDescending(x => x.TraineePictureId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineePictureDtos = _mapper.Map<List<TraineePictureDto>>(TraineePictures);
            var result = new PagedResult<TraineePictureDto>(TraineePictureDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
