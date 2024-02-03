using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeReligationDto
    {
        public int TraineeNominationId { get; set; }
        public string? WithdrawnRemarks { get; set; } 
        public int? WithdrawnTypeId { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public string? WithdrawnDocs { get; set; }
        public IFormFile? Doc { get; set; }
    }
}
