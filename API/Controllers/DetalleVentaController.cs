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
public class DetalleVentaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> Get()
        {
            var DetalleVentaes = await _unitOfWork.DetallesVentas.GetAllAsync();
            return _mapper.Map<List<DetalleVenta>>(DetalleVentaes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Get(int id)
        {
            var DetalleVenta = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
            if(DetalleVenta == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleVentaDto>(DetalleVenta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleVenta>> Post(DetalleVentaDto DetalleVentaDto)
        {
            var DetalleVenta = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            this._unitOfWork.DetallesVentas.Add(DetalleVenta);
            await _unitOfWork.SaveAsync();
            if(DetalleVenta == null)
            {
                return BadRequest();
            }
            DetalleVentaDto.Id = DetalleVenta.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleVentaDto.Id}, DetalleVentaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody] DetalleVentaDto DetalleVentaDto)
        {
            if(DetalleVentaDto == null)
            {
                return NotFound();
            }
            var DetalleVentaes = _mapper.Map<DetalleVenta>(DetalleVentaDto);
            _unitOfWork.DetallesVentas.Update(DetalleVentaes);
            await _unitOfWork.SaveAsync();
            return DetalleVentaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DetalleVenta = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
            if(DetalleVenta == null)
            {
                return NotFound();
            }
            _unitOfWork.DetallesVentas.Remove(DetalleVenta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }