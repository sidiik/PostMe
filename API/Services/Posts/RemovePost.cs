using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core;
using MediatR;
using ReactivitiesV1.Data;

namespace ReactivitiesV1.Services.Posts
{
    public class RemovePost
    {
        public class Command : IRequest<Result<string>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<string>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var deletingPost = await _context.Posts.FindAsync(request.Id);
                if (deletingPost is null) return Result<string>.Failure("We're sorry, but the post you are looking for is no longer available");
                _context.Posts.Remove(deletingPost);
                await _context.SaveChangesAsync();
                return Result<string>.Success($"Post removed successfuly, POSTID:{request.Id}");
            }
        }
    }
}