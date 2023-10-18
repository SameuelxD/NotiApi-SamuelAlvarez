using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RolVsMaestroController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolVsMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolVsMaestroDto>>> Get()
    {
        var rolvsmaestros = await _unitOfWork.RolVsMaestros.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<RolVsMaestroDto>>(rolvsmaestros);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestro>> Post(RolVsMaestroDto rolvsmaestroDto)
    {
        var rolvsmaestro = _mapper.Map<RolVsMaestro>(rolvsmaestroDto);
        this._unitOfWork.RolVsMaestros.Add(rolvsmaestro);
        await _unitOfWork.SaveAsync();
        if (rolvsmaestro == null)
        {
            return BadRequest();
        }
        rolvsmaestroDto.Id = rolvsmaestro.Id;
        return CreatedAtAction(nameof(Post), new { id = rolvsmaestroDto.Id }, rolvsmaestroDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolVsMaestroDto>> Get(int id)
    {
        var rolvsmaestro = await _unitOfWork.RolVsMaestros.GetByIdAsync(id);
        if (rolvsmaestro == null){
            return NotFound();
        }
        return _mapper.Map<RolVsMaestroDto>(rolvsmaestro);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolVsMaestroDto>> Put(int id, [FromBody] RolVsMaestroDto rolvsmaestroDto)
    {
        if (rolvsmaestroDto == null)
        {
            return NotFound();
        }
        var rolvsmaestros = _mapper.Map<RolVsMaestro>(rolvsmaestroDto);
        _unitOfWork.RolVsMaestros.Update(rolvsmaestros);
        await _unitOfWork.SaveAsync();
        return rolvsmaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rolvsmaestro = await _unitOfWork.RolVsMaestros.GetByIdAsync(id);
        if (rolvsmaestro == null)
        {
            return NotFound();
        }
        _unitOfWork.RolVsMaestros.Remove(rolvsmaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}


