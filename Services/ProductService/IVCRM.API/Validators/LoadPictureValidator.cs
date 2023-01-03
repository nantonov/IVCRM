using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class LoadPictureValidator : AbstractValidator<LoadPictureViewModel>
    {
        public LoadPictureValidator()
        {
            RuleFor(x => x.Picture).SetValidator(new FileValidator());
        }
    }
}
