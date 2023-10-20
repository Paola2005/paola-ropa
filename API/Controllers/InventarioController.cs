using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class InventarioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Inventario>>> Get()
        {
            var Inventarioes = await _unitOfWork.Inventarios.GetAllAsync();
            return _mapper.Map<List<Inventario>>(Inventarioes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> Get(int id)
        {
            var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if(Inventario == null)
            {
                return NotFound();
            }
            return _mapper.Map<InventarioDto>(Inventario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Inventario>> Post(InventarioDto InventarioDto)
        {
            var Inventario = _mapper.Map<Inventario>(InventarioDto);
            this._unitOfWork.Inventarios.Add(Inventario);
            await _unitOfWork.SaveAsync();
            if(Inventario == null)
            {
                return BadRequest();
            }
            InventarioDto.Id = Inventario.Id;
            return CreatedAtAction(nameof(Post), new {id = InventarioDto.Id}, InventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody] InventarioDto InventarioDto)
        {
            if(InventarioDto == null)
            {
                return NotFound();
            }
            var Inventarioes = _mapper.Map<Inventario>(InventarioDto);
            _unitOfWork.Inventarios.Update(Inventarioes);
            await _unitOfWork.SaveAsync();
            return InventarioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            if(Inventario == null)
            {
                return NotFound();
            }
            _unitOfWork.Inventarios.Remove(Inventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }