using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuditoriaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
    {
        var auditorias = await _unitOfWork.Auditorias.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<AuditoriaDto>>(auditorias);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditoria>> Post(AuditoriaDto auditoriaDto)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
        this._unitOfWork.Auditorias.Add(auditoria);
        await _unitOfWork.SaveAsync();
        if (auditoria == null)
        {
            return BadRequest();
        }
        auditoriaDto.Id = auditoria.Id;
        return CreatedAtAction(nameof(Post), new { id = auditoriaDto.Id }, auditoriaDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditoriaDto>> Get(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if (auditoria == null){
            return NotFound();
        }
        return _mapper.Map<AuditoriaDto>(auditoria);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
    {
        if (auditoriaDto == null)
        {
            return NotFound();
        }
        var auditorias = _mapper.Map<Auditoria>(auditoriaDto);
        _unitOfWork.Auditorias.Update(auditorias);
        await _unitOfWork.SaveAsync();
        return auditoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if (auditoria == null)
        {
            return NotFound();
        }
        _unitOfWork.Auditorias.Remove(auditoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}