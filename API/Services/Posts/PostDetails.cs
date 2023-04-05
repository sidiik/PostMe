using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;

namespace ReactivitiesV1.Services
{
    public class PostDetails
    {
        public class Query : IRequest<Result<Post>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Post>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Post>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id);
                if (post is null) return Result<Post>.Failure("We're sorry, but the post you are looking for is no longer available");

                return Result<Post>.Success(post);
            }
        }
    }
}