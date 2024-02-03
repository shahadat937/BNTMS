﻿using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Religions.Requests.Queries
{
    public class GetSelectedReligionRequest : IRequest<List<SelectedModel>>
    {
    }
}
