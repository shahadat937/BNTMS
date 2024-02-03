using FluentValidation;


namespace SchoolManagement.Application.DTOs.RoutineNote.Validators
{
    public class UpdateRoutineNoteDtoValidator : AbstractValidator<CreateRoutineNoteDto>
    {
        public UpdateRoutineNoteDtoValidator()
        {
            Include(new IRoutineNoteDtoValidator());

            //RuleFor(p => p.ReligionId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.RoutineNoteId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
