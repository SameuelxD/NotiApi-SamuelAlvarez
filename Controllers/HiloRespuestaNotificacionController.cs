using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class HiloRespuestaNotificacionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HiloRespuestaNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<HiloRespuestaNotificacionDto>>> Get()
    {
        var hilorespuestasnotificaciones = await _unitOfWork.HiloRespuestasNotificaciones.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<HiloRespuestaNotificacionDto>>(hilorespuestasnotificaciones);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HiloRespuestaNotificacion>> Post(HiloRespuestaNotificacionDto hilorespuestanotificacionDto)
    {
        var hilorespuestanotificacion = _mapper.Map<HiloRespuestaNotificacion>(hilorespuestanotificacionDto);
        this._unitOfWork.HiloRespuestasNotificaciones.Add(hilorespuestanotificacion);
        await _unitOfWork.SaveAsync();
        if (hilorespuestanotificacion == null)
        {
            return BadRequest();
        }
        hilorespuestanotificacionDto.Id = hilorespuestanotificacion.Id;
        return CreatedAtAction(nameof(Post), new { id = hilorespuestanotificacionDto.Id }, hilorespuestanotificacionDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HiloRespuestaNotificacionDto>> Get(int id)
    {
        var hilorespuestanotificacion = await _unitOfWork.HiloRespuestasNotificaciones.GetByIdAsync(id);
        if (hilorespuestanotificacion == null){
            return NotFound();
        }
        return _mapper.Map<HiloRespuestaNotificacionDto>(hilorespuestanotificacion);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HiloRespuestaNotificacionDto>> Put(int id, [FromBody] HiloRespuestaNotificacionDto hilorespuestanotificacionDto)
    {
        if (hilorespuestanotificacionDto == null)
        {
            return NotFound();
        }
        var hilorespuestasnotificaciones = _mapper.Map<HiloRespuestaNotificacion>(hilorespuestanotificacionDto);
        _unitOfWork.HiloRespuestasNotificaciones.Update(hilorespuestasnotificaciones);
        await _unitOfWork.SaveAsync();
        return hilorespuestanotificacionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var hilorespuestanotificacion = await _unitOfWork.HiloRespuestasNotificaciones.GetByIdAsync(id);
        if (hilorespuestanotificacion == null)
        {
            return NotFound();
        }
        _unitOfWork.HiloRespuestasNotificaciones.Remove(hilorespuestanotificacion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}