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
public class GeneroController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            var Generoes = await _unitOfWork.Generos.GetAllAsync();
            return _mapper.Map<List<Genero>>(Generoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeneroDto>> Get(int id)
        {
            var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
            if(Genero == null)
            {
                return NotFound();
            }
            return _mapper.Map<GeneroDto>(Genero);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Genero>> Post(GeneroDto GeneroDto)
        {
            var Genero = _mapper.Map<Genero>(GeneroDto);
            this._unitOfWork.Generos.Add(Genero);
            await _unitOfWork.SaveAsync();
            if(Genero == null)
            {
                return BadRequest();
            }
            GeneroDto.Id = Genero.Id;
            return CreatedAtAction(nameof(Post), new {id = GeneroDto.Id}, GeneroDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody] GeneroDto GeneroDto)
        {
            if(GeneroDto == null)
            {
                return NotFound();
            }
            var Generoes = _mapper.Map<Genero>(GeneroDto);
            _unitOfWork.Generos.Update(Generoes);
            await _unitOfWork.SaveAsync();
            return GeneroDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Genero = await _unitOfWork.Generos.GetByIdAsync(id);
            if(Genero == null)
            {
                return NotFound();
            }
            _unitOfWork.Generos.Remove(Genero);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }