using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectAfaceriElectronice.Models;
using ProiectAfaceriElectronice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectAfaceriElectronice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaliiComenziController : ControllerBase
    {
        private readonly IDetaliiComenzi _prodRepo;

        public DetaliiComenziController(IDetaliiComenzi produsRepo)
        {
            _prodRepo = produsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detaliicomenzi>>> GetProduse()
        {
            try
            {
                return (await _prodRepo.Get()).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database!");
            }
        }

        [HttpGet("search/{den}")]
        public async Task<ActionResult<Detaliicomenzi>> GetProdByName(string den)
        {
            try
            {
                var result = await _prodRepo.GetByDen(den);
                if (result == null)
                {
                    return NotFound("No records found");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Detaliicomenzi>> GetProdById(int id)
        {
            try
            {
                var result = await _prodRepo.GetById(id);
                if (result == null)
                {
                    return NotFound("No records found");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Detaliicomenzi>> CreateProdus([FromBody] Detaliicomenzi prod)
        {
            try
            {
                if (prod == null)
                {
                    return BadRequest("The records are empty!");
                }
                else
                {
                    var createProd = await _prodRepo.Create(prod);
                    return CreatedAtAction(nameof(GetProduse), new { id = createProd.Idprodus }, createProd);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Detaliicomenzi>> UpdateProd(int id, [FromBody] Detaliicomenzi prod)
        {
            try
            {
                if (id != prod.Idcomanda)
                {
                    return BadRequest("ID mismatch");
                }
                else
                {
                    await _prodRepo.Update(prod);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prodToDelete = await _prodRepo.GetById(id);
            if (prodToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await _prodRepo.Delete(prodToDelete.Idcomanda);
                return NoContent();
            }
        }
    }
}
