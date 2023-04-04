using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReactivitiesV1.Data;
using ReactivitiesV1.Domain;
using ReactivitiesV1.DTO.Post;

namespace ReactivitiesV1.Services.Posts
{
    public class EditPost
    {
        public class Command : IRequest
        {
            public EditPostDto Post { get; set; }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Post.LastUpdatedAt = DateTime.Now;
                var editingPost = await _context.Posts.FindAsync(request.Id);
                _mapper.Map(request.Post, editingPost);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}