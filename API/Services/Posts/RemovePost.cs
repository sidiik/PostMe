using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ReactivitiesV1.Data;

namespace ReactivitiesV1.Services.Posts
{
    public class RemovePost
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var deletingPost = await _context.Posts.FindAsync(request.Id);
                _context.Posts.Remove(deletingPost);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}