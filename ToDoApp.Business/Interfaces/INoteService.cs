using ToDoApp.Common1.ResponseObjects;

using ToDoApp.Dtos1.Dtos;


namespace ToDoApp.Business.Interfaces
{
    public interface INoteService
    {
        Task<IResponse<List<NoteListDto>>> GetAll();
        Task<IResponse<NoteCreateDto>> Create(NoteCreateDto dto);
        Task<IResponse<IDto>> GetByİd<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<NoteUpdateDto>> Update(NoteUpdateDto dto);

    }
}
