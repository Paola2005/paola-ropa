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
public class FormaPagoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormaPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormaPago>>> Get()
        {
            var FormaPagoes = await _unitOfWork.FormasPagos.GetAllAsync();
            return _mapper.Map<List<FormaPago>>(FormaPagoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Get(int id)
        {
            var FormaPago = await _unitOfWork.FormasPagos.GetByIdAsync(id);
            if(FormaPago == null)
            {
                return NotFound();
            }
            return _mapper.Map<FormaPagoDto>(FormaPago);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
        {
            var FormaPago = _mapper.Map<FormaPago>(FormaPagoDto);
            this._unitOfWork.FormasPagos.Add(FormaPago);
            await _unitOfWork.SaveAsync();
            if(FormaPago == null)
            {
                return BadRequest();
            }
            FormaPagoDto.Id = FormaPago.Id;
            return CreatedAtAction(nameof(Post), new {id = FormaPagoDto.Id}, FormaPagoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody] FormaPagoDto FormaPagoDto)
        {
            if(FormaPagoDto == null)
            {
                return NotFound();
            }
            var FormaPagoes = _mapper.Map<FormaPago>(FormaPagoDto);
            _unitOfWork.FormasPagos.Update(FormaPagoes);
            await _unitOfWork.SaveAsync();
            return FormaPagoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var FormaPago = await _unitOfWork.FormasPagos.GetByIdAsync(id);
            if(FormaPago == null)
            {
                return NotFound();
            }
            _unitOfWork.FormasPagos.Remove(FormaPago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }