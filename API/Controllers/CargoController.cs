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
public class CargoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Cargo>>> Get()
        {
            var Cargoes = await _unitOfWork.Cargos.GetAllAsync();
            return _mapper.Map<List<Cargo>>(Cargoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoDto>> Get(int id)
        {
            var Cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
            if(Cargo == null)
            {
                return NotFound();
            }
            return _mapper.Map<CargoDto>(Cargo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cargo>> Post(CargoDto CargoDto)
        {
            var Cargo = _mapper.Map<Cargo>(CargoDto);
            this._unitOfWork.Cargos.Add(Cargo);
            await _unitOfWork.SaveAsync();
            if(Cargo == null)
            {
                return BadRequest();
            }
            CargoDto.Id = Cargo.Id;
            return CreatedAtAction(nameof(Post), new {id = CargoDto.Id}, CargoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto CargoDto)
        {
            if(CargoDto == null)
            {
                return NotFound();
            }
            var Cargoes = _mapper.Map<Cargo>(CargoDto);
            _unitOfWork.Cargos.Update(Cargoes);
            await _unitOfWork.SaveAsync();
            return CargoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
            if(Cargo == null)
            {
                return NotFound();
            }
            _unitOfWork.Cargos.Remove(Cargo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }