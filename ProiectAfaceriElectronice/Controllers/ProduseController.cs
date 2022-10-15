using Microsoft.AspNetCore.Cors;
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
    public class ProduseController : ControllerBase
    {
        private readonly IProdus _prodRepo;

        public ProduseController(IProdus produsRepo)
        {
            _prodRepo = produsRepo;
        }

        [EnableCors("_myAllow")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produse>>> GetProduse()
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
        public async Task<ActionResult<Produse>> GetProdByName(string den)
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
        public async Task<ActionResult<Produse>> GetProdById(int id)
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
        public async Task<ActionResult<Produse>> CreateProdus([FromBody] Produse prod)
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
        public async Task<ActionResult<Produse>> UpdateProd(int id, [FromBody] Produse prod)
        {
            try
            {
                if (id != prod.Idprodus)
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
                await _prodRepo.Delete(prodToDelete.Idprodus);
                return NoContent();
            }
        }
    }
}
