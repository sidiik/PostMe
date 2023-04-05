using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core;
using API.Services.Posts;
using AutoMapper;
using FluentValidation;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO.Post;

namespace ReactivitiesV1.Services.Posts
{
    public class EditPost
    {
        public class Command : IRequest<Result<Post>>
        {
            public EditPostDto Post { get; set; }
            public int Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Post).SetValidator(new EditPostValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Post>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Post>> Handle(Command request, CancellationToken cancellationToken)
            {
                var editingPost = await _context.Posts.FindAsync(request.Id);

                if (editingPost is null) return Result<Post>.Failure("We're sorry, but the post you are looking for is no longer available");

                editingPost.LastUpdatedAt = DateTime.Now;
                _mapper.Map(request.Post, editingPost);
                await _context.SaveChangesAsync();

                return Result<Post>.Success(editingPost);
            }
        }
    }
}