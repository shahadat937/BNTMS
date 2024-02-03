using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentTypes.Handlers.Queries
{
    public class GetSelectedPaymentTypeRequestHandler : IRequestHandler<GetSelectedPaymentTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PaymentType> _PaymentTypeRepository;


        public GetSelectedPaymentTypeRequestHandler(ISchoolManagementRepository<PaymentType> PaymentTypeRepository)
        {
            _PaymentTypeRepository = PaymentTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPaymentTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<PaymentType> codeValues = await _PaymentTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PaymentTypeName,
                Value = x.PaymentTypeId
            }).ToList();
            return selectModels;
        }
    }
}
