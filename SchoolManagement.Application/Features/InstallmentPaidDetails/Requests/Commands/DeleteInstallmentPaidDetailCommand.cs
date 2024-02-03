using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands
{
    public class DeleteInstallmentPaidDetailCommand : IRequest
    {  
        public int Id { get; set; }
    }
}
