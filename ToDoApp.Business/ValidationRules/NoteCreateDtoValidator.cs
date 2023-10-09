using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos1.Dtos;

namespace ToDoApp.Business.ValidationRules
{
    public class NoteCreateDtoValidator : AbstractValidator<NoteCreateDto>
    {
        public NoteCreateDtoValidator()
        {

            RuleFor(x => x.Defination).NotEmpty().WithMessage("definition is required");



        }
    }
}
