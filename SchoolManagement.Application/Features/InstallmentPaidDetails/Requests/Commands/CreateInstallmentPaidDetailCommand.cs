using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands 
{
    public class CreateInstallmentPaidDetailCommand : IRequest<BaseCommandResponse> 
    {
        public CreateInstallmentPaidDetailDto InstallmentPaidDetailDto { get; set; }    

    }
}
