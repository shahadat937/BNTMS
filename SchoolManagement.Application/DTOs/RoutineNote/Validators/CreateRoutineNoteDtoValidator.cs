using FluentValidation;

namespace SchoolManagement.Application.DTOs.RoutineNote.Validators
{
    public class CreateRoutineNoteDtoValidator : AbstractValidator<CreateRoutineNoteDto>
    {
        public CreateRoutineNoteDtoValidator()
        {
            Include(new IRoutineNoteDtoValidator());
        }
    }
}
