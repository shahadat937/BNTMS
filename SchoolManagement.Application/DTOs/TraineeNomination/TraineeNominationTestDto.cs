using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeNominationTestDto 
    {
        public int courseNameId { get; set; }
        public int? status { get; set; }
        public int? traineeId { get; set; }        
    }
}
