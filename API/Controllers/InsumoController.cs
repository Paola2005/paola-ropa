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
public class InsumoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsumoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Insumo>>> Get()
        {
            var Insumoes = await _unitOfWork.Insumos.GetAllAsync();
            return _mapper.Map<List<Insumo>>(Insumoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Get(int id)
        {
            var Insumo = await _unitOfWork.Insumos.GetByIdAsync(id);
            if(Insumo == null)
            {
                return NotFound();
            }
            return _mapper.Map<InsumoDto>(Insumo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
        {
            var Insumo = _mapper.Map<Insumo>(InsumoDto);
            this._unitOfWork.Insumos.Add(Insumo);
            await _unitOfWork.SaveAsync();
            if(Insumo == null)
            {
                return BadRequest();
            }
            InsumoDto.Id = Insumo.Id;
            return CreatedAtAction(nameof(Post), new {id = InsumoDto.Id}, InsumoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InsumoDto>> Put(int id, [FromBody] InsumoDto InsumoDto)
        {
            if(InsumoDto == null)
            {
                return NotFound();
            }
            var Insumoes = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Update(Insumoes);
            await _unitOfWork.SaveAsync();
            return InsumoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Insumo = await _unitOfWork.Insumos.GetByIdAsync(id);
            if(Insumo == null)
            {
                return NotFound();
            }
            _unitOfWork.Insumos.Remove(Insumo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }