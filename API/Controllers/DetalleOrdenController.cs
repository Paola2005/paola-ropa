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
public class DetalleOrdenController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> Get()
        {
            var DetalleOrdenes = await _unitOfWork.DetallesOrdenes.GetAllAsync();
            return _mapper.Map<List<DetalleOrden>>(DetalleOrdenes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
        {
            var DetalleOrden = await _unitOfWork.DetallesOrdenes.GetByIdAsync(id);
            if(DetalleOrden == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleOrdenDto>(DetalleOrden);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleOrden>> Post(DetalleOrdenDto DetalleOrdenDto)
        {
            var DetalleOrden = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            this._unitOfWork.DetallesOrdenes.Add(DetalleOrden);
            await _unitOfWork.SaveAsync();
            if(DetalleOrden == null)
            {
                return BadRequest();
            }
            DetalleOrdenDto.Id = DetalleOrden.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleOrdenDto.Id}, DetalleOrdenDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody] DetalleOrdenDto DetalleOrdenDto)
        {
            if(DetalleOrdenDto == null)
            {
                return NotFound();
            }
            var DetalleOrdenes = _mapper.Map<DetalleOrden>(DetalleOrdenDto);
            _unitOfWork.DetallesOrdenes.Update(DetalleOrdenes);
            await _unitOfWork.SaveAsync();
            return DetalleOrdenDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DetalleOrden = await _unitOfWork.DetallesOrdenes.GetByIdAsync(id);
            if(DetalleOrden == null)
            {
                return NotFound();
            }
            _unitOfWork.DetallesOrdenes.Remove(DetalleOrden);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }