using AutoMapper;
using BiblioApi.Dtos.Book;
using BiblioApi.Entities;

namespace BiblioApi.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile(){
            
            // Source Model -> Target Model
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            // For PATCH we need to be able to create the updateDTO from the base model
            CreateMap<Book, UpdateBookDto>();
        }
    }
}