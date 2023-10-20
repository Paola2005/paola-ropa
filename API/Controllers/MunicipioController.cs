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
public class MunicipioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MunicipioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Municipio>>> Get()
        {
            var Municipioes = await _unitOfWork.Municipios.GetAllAsync();
            return _mapper.Map<List<Municipio>>(Municipioes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MunicipioDto>> Get(int id)
        {
            var Municipio = await _unitOfWork.Municipios.GetByIdAsync(id);
            if(Municipio == null)
            {
                return NotFound();
            }
            return _mapper.Map<MunicipioDto>(Municipio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Municipio>> Post(MunicipioDto MunicipioDto)
        {
            var Municipio = _mapper.Map<Municipio>(MunicipioDto);
            this._unitOfWork.Municipios.Add(Municipio);
            await _unitOfWork.SaveAsync();
            if(Municipio == null)
            {
                return BadRequest();
            }
            MunicipioDto.Id = Municipio.Id;
            return CreatedAtAction(nameof(Post), new {id = MunicipioDto.Id}, MunicipioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MunicipioDto>> Put(int id, [FromBody] MunicipioDto MunicipioDto)
        {
            if(MunicipioDto == null)
            {
                return NotFound();
            }
            var Municipioes = _mapper.Map<Municipio>(MunicipioDto);
            _unitOfWork.Municipios.Update(Municipioes);
            await _unitOfWork.SaveAsync();
            return MunicipioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Municipio = await _unitOfWork.Municipios.GetByIdAsync(id);
            if(Municipio == null)
            {
                return NotFound();
            }
            _unitOfWork.Municipios.Remove(Municipio);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }