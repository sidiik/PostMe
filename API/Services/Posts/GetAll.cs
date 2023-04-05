using API.Core;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;

namespace ReactivitiesV1.Services
{
    public class GetAll
    {
        public class Query : IRequest<Result<List<Post>>> { };

        public class Handler : IRequestHandler<Query, Result<List<Post>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Post>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Post>>.Success(await _context.Posts.ToListAsync(cancellationToken));
            }
        }
    }
}