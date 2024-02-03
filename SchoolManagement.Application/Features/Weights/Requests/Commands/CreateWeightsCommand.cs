using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.Weight;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Weights.Requests.Commands 
{
    public class CreateWeightsCommand : IRequest<BaseCommandResponse> 
    {
        public CreateWeightDto WeightDto { get; set; }      

    }
}
