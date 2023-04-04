using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;

namespace ReactivitiesV1.Services
{
    public class PostDetails
    {
        public class Query : IRequest<Post>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.FindAsync(request.Id);
            }
        }
    }
}