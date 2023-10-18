using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GenericosVsSubmoduloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericosVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericosVsSubmoduloDto>>> Get()
    {
        var genericosvssubmodulos = await _unitOfWork.GenericosVsSubmodulos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<GenericosVsSubmoduloDto>>(genericosvssubmodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Formato>> Post(GenericosVsSubmoduloDto genericosvssubmoduloDto)
    {
        var genericosvssubmodulo = _mapper.Map<GenericosVsSubmodulo>(genericosvssubmoduloDto);
        this._unitOfWork.GenericosVsSubmodulos.Add(genericosvssubmodulo);
        await _unitOfWork.SaveAsync();
        if (genericosvssubmodulo == null)
        {
            return BadRequest();
        }
        genericosvssubmoduloDto.Id = genericosvssubmodulo.Id;
        return CreatedAtAction(nameof(Post), new { id = genericosvssubmoduloDto.Id }, genericosvssubmoduloDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericosVsSubmoduloDto>> Get(int id)
    {
        var genericosvssubmodulo = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);
        if (genericosvssubmodulo == null){
            return NotFound();
        }
        return _mapper.Map<GenericosVsSubmoduloDto>(genericosvssubmodulo);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericosVsSubmoduloDto>> Put(int id, [FromBody] GenericosVsSubmoduloDto genericosvssubmoduloDto)
    {
        if (genericosvssubmoduloDto == null)
        {
            return NotFound();
        }
        var genericosvssubmodulos = _mapper.Map<GenericosVsSubmodulo>(genericosvssubmoduloDto);
        _unitOfWork.GenericosVsSubmodulos.Update(genericosvssubmodulos);
        await _unitOfWork.SaveAsync();
        return genericosvssubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var genericosvssubmodulo = await _unitOfWork.GenericosVsSubmodulos.GetByIdAsync(id);
        if (genericosvssubmodulo == null)
        {
            return NotFound();
        }
        _unitOfWork.GenericosVsSubmodulos.Remove(genericosvssubmodulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}