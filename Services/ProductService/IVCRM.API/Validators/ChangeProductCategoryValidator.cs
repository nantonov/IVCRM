using FluentValidation;
using IVCRM.API.ViewModels;

namespace IVCRM.API.Validators
{
    public class ChangeProductCategoryValidator :AbstractValidator<ChangeProductCategoryViewModel>
    {
        public ChangeProductCategoryValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Please add a category name");
        }
    }
}
