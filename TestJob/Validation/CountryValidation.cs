using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TestJob.Models.Dto;

namespace TestJob.Validation
{
    public class CountryValidation : AbstractValidator<CountryDto>
    {
        public CountryValidation()
        {
            RuleFor(x => x.CodeСountry)
              .NotEmpty().WithMessage(ValidationMessages.CodeCountry);
            RuleFor(x => x.CityName)
            .NotEmpty().WithMessage(ValidationMessages.City);
            RuleFor(x => x.RegionName)
            .NotEmpty().WithMessage(ValidationMessages.Region);    
        }
    }
    
}
