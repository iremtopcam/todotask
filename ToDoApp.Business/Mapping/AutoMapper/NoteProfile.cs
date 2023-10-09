using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos1.Dtos;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.Business.Mapping.AutoMapper
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteListDto>().ReverseMap();
            CreateMap<Note, NoteCreateDto>().ReverseMap();
            CreateMap<Note, NoteUpdateDto>().ReverseMap();
            CreateMap<NoteListDto, NoteUpdateDto>().ReverseMap();
        }
    }
}
