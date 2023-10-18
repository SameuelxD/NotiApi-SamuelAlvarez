using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoRequerimientoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
    {
        var tiposrequerimientos = await _unitOfWork.TiposRequerimientos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<TipoRequerimientoDto>>(tiposrequerimientos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoRequerimiento>> Post(TipoRequerimientoDto tiporequerimientoDto)
    {
        var tiporequerimiento = _mapper.Map<TipoRequerimiento>(tiporequerimientoDto);
        this._unitOfWork.TiposRequerimientos.Add(tiporequerimiento);
        await _unitOfWork.SaveAsync();
        if (tiporequerimiento == null)
        {
            return BadRequest();
        }
        tiporequerimientoDto.Id = tiporequerimiento.Id;
        return CreatedAtAction(nameof(Post), new { id = tiporequerimientoDto.Id }, tiporequerimientoDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Get(int id)
    {
        var tiporequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
        if (tiporequerimiento == null){
            return NotFound();
        }
        return _mapper.Map<TipoRequerimientoDto>(tiporequerimiento);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto tiporequerimientoDto)
    {
        if (tiporequerimientoDto == null)
        {
            return NotFound();
        }
        var tiposrequerimientos = _mapper.Map<TipoRequerimiento>(tiporequerimientoDto);
        _unitOfWork.TiposRequerimientos.Update(tiposrequerimientos);
        await _unitOfWork.SaveAsync();
        return tiporequerimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tiporequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
        if (tiporequerimiento == null)
        {
            return NotFound();
        }
        _unitOfWork.TiposRequerimientos.Remove(tiporequerimiento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
