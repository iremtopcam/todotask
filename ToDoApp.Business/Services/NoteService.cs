using AutoMapper;
using FluentValidation;
using ToDoApp.Business.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Interfaces;
using ToDoApp.Common1.ResponseObjects;
using ToDoApp.DataAccess1.UnitOfWork;
using ToDoApp.Dtos1.Dtos;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.Business.Services;
     public class NoteService : INoteService

{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    private readonly IValidator<NoteCreateDto> _createDtoValidator;
    private readonly IValidator<NoteUpdateDto> _updateDtoValidator;
    public NoteService(IUow uow, IMapper mapper, IValidator<NoteCreateDto> createDtoValidator, IValidator<NoteUpdateDto> updateDtoValidator)
    {
        _uow = uow;
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _updateDtoValidator = updateDtoValidator;
    }

    public async Task<IResponse<NoteCreateDto>> Create(NoteCreateDto dto)
    {
        var validationResult = _createDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            await _uow.GetRepository<Note>().Create(_mapper.Map<Note>(dto));
            await _uow.SaveChanges();
            return new Response<NoteCreateDto>(ResponseType.Success, dto);
        }
        return new Response<NoteCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());

    }

    public async Task<IResponse<List<NoteListDto>>> GetAll()
    {
        var data = _mapper.Map<List<NoteListDto>>(await _uow.GetRepository<Note>().GetAll());

        return new Response<List<NoteListDto>>(ResponseType.Success, data);
    }

    public async Task<IResponse<IDto>> GetByİd<IDto>(int id)
    {
        var result = _mapper.Map<IDto>(await _uow.GetRepository<Note>().GetByFilter(x => x.Id == id));
        if (result == null)
        {
            return new Response<IDto>(ResponseType.NotFound, $"{id} id data not found");
        }

        return new Response<IDto>(ResponseType.Success, result);

    }

    public async Task<IResponse> Remove(int id)
    {
        //get by filter ile çekme nedenimiz takibe ihtiyac yok
        var removedEntity = await _uow.GetRepository<Note>().GetByFilter(x => x.Id == id);

        if (removedEntity != null)
        {
            _uow.GetRepository<Note>().Remove(removedEntity);
            await _uow.SaveChanges();
            return new Response(ResponseType.Success);
        }

        return new Response(ResponseType.NotFound, $"{id} id data not found");


    }

    public async Task<IResponse<NoteUpdateDto>> Update(NoteUpdateDto dto)
    {

        var validationResult = _updateDtoValidator.Validate(dto);

        if (validationResult.IsValid)
        {
            var updatedEntity = await _uow.GetRepository<Note>().Find(dto.Id);

            if (updatedEntity != null)
            {
                _uow.GetRepository<Note>().Update(_mapper.Map<Note>(dto), updatedEntity);
                await _uow.SaveChanges();
                return new Response<NoteUpdateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<NoteUpdateDto>(ResponseType.NotFound, dto);
            }

        }


        return new Response<NoteUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());






    }


}

