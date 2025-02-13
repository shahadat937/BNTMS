﻿using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSemester
{
    public class CreateBnaSemesterDto : IBnaSemesterDto 
    {
        public int BnaSemesterId { get; set; }
        public string SemesterName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
