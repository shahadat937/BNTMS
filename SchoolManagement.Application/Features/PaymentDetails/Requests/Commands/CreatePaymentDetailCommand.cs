using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Commands 
{
    public class CreatePaymentDetailCommand : IRequest<BaseCommandResponse> 
    {
        public CreatePaymentDetailDto PaymentDetailDto { get; set; }    

    }
}
