using AutoMapper;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO;

namespace ReactivitiesV1.Services
{
    public class CreatePost
    {
        public class Command : IRequest
        {
            public ModifyPost Post { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            public Handler(IMapper mapper, DataContext context)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var newPost = _mapper.Map<Post>(request.Post);
                newPost.CreatedAt = DateTime.Now;
                newPost.LastUpdatedAt = DateTime.Now;
                await _context.Posts.AddAsync(newPost);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}