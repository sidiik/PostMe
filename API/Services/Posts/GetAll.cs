using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;

namespace ReactivitiesV1.Services
{
    public class GetAll
    {
        public class Query : IRequest<List<Post>> { };

        public class Handler : IRequestHandler<Query, List<Post>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Post>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.ToListAsync();
            }
        }
    }
}