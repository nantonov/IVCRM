using FluentValidation;

namespace IVCRM.API.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.ContentType).NotNull()
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("That file type is not allowed, load jpeg, jpg, or png");
        }
    }
}
