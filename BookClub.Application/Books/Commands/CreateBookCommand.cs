using MediatR;

namespace BookClub.Application.Books.Commands
{
    // Минимум для создания книги
    public class CreateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string[] Tags { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }


    }
}
