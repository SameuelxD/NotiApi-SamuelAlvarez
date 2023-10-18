using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MaestrosVsSubmoduloController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaestrosVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MaestrosVsSubmoduloDto>>> Get()
    {
        var maestrosvssubmodulos = await _unitOfWork.MaestrosVsSubmodulos.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<MaestrosVsSubmoduloDto>>(maestrosvssubmodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestrosVsSubmodulo>> Post(MaestrosVsSubmoduloDto maestrosvssubmoduloDto)
    {
        var maestrosvssubmodulo = _mapper.Map<MaestrosVsSubmodulo>(maestrosvssubmoduloDto);
        this._unitOfWork.MaestrosVsSubmodulos.Add(maestrosvssubmodulo);
        await _unitOfWork.SaveAsync();
        if (maestrosvssubmodulo == null)
        {
            return BadRequest();
        }
        maestrosvssubmoduloDto.Id = maestrosvssubmodulo.Id;
        return CreatedAtAction(nameof(Post), new { id = maestrosvssubmoduloDto.Id }, maestrosvssubmoduloDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestrosVsSubmoduloDto>> Get(int id)
    {
        var maestrosvssubmodulo = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(id);
        if (maestrosvssubmodulo == null){
            return NotFound();
        }
        return _mapper.Map<MaestrosVsSubmoduloDto>(maestrosvssubmodulo);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestrosVsSubmoduloDto>> Put(int id, [FromBody] MaestrosVsSubmoduloDto maestrosvssubmoduloDto)
    {
        if (maestrosvssubmoduloDto == null)
        {
            return NotFound();
        }
        var maestrosvssubmodulos = _mapper.Map<MaestrosVsSubmodulo>(maestrosvssubmoduloDto);
        _unitOfWork.MaestrosVsSubmodulos.Update(maestrosvssubmodulos);
        await _unitOfWork.SaveAsync();
        return maestrosvssubmoduloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var maestrosvssubmodulo = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(id);
        if (maestrosvssubmodulo == null)
        {
            return NotFound();
        }
        _unitOfWork.MaestrosVsSubmodulos.Remove(maestrosvssubmodulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}