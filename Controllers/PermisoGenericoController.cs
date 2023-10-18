using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PermisoGenericoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermisoGenericoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PermisoGenericoDto>>> Get()
    {
        var permisosgenericos = await _unitOfWork.PermisosGenericos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PermisoGenericoDto>>(permisosgenericos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisoGenerico>> Post(PermisoGenericoDto permisogenericoDto)
    {
        var permisogenerico = _mapper.Map<PermisoGenerico>(permisogenericoDto);
        this._unitOfWork.PermisosGenericos.Add(permisogenerico);
        await _unitOfWork.SaveAsync();
        if (permisogenerico == null)
        {
            return BadRequest();
        }
        permisogenericoDto.Id = permisogenerico.Id;
        return CreatedAtAction(nameof(Post), new { id = permisogenericoDto.Id }, permisogenericoDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisoGenericoDto>> Get(int id)
    {
        var permisogenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permisogenerico == null){
            return NotFound();
        }
        return _mapper.Map<PermisoGenericoDto>(permisogenerico);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisoGenericoDto>> Put(int id, [FromBody] PermisoGenericoDto permisogenericoDto)
    {
        if (permisogenericoDto == null)
        {
            return NotFound();
        }
        var permisosgenericos = _mapper.Map<PermisoGenerico>(permisogenericoDto);
        _unitOfWork.PermisosGenericos.Update(permisosgenericos);
        await _unitOfWork.SaveAsync();
        return permisogenericoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var permisogenerico = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permisogenerico == null)
        {
            return NotFound();
        }
        _unitOfWork.PermisosGenericos.Remove(permisogenerico);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}