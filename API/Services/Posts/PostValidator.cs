using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ReactivitiesV1.DTO;
using ReactivitiesV1.DTO.Post;

namespace API.Services.Posts
{
    public class CreatePostValidotr : AbstractValidator<ModifyPost>
    {
        public CreatePostValidotr()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.IsPublished).NotNull();

        }
    }
    public class EditPostValidator : AbstractValidator<EditPostDto>
    {
        public EditPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.IsPublished).NotNull();

        }
    }
}