﻿using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Queries
{
    public class GetSelectedExamCenterRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  