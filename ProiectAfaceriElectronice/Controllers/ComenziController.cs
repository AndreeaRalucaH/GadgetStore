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
    public class ComenziController : ControllerBase
    {
        private readonly IComenzi _comRepo;

        public ComenziController(IComenzi comRepo)
        {
            _comRepo = comRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comenzi>>> GetProduse()
        {
            try
            {
                return (await _comRepo.Get()).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database!");
            }
        }

        //[HttpGet("search/{den}")]
        //public async Task<ActionResult<Produse>> GetProdByName(string den)
        //{
        //    try
        //    {
        //        var result = await _comRepo..Ge(den);
        //        if (result == null)
        //        {
        //            return NotFound("No records found");
        //        }
        //        else
        //        {
        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database!");
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Comenzi>> GetProdById(int id)
        {
            try
            {
                var result = await _comRepo.GetById(id);
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
        public async Task<ActionResult<Comenzi>> CreateProdus([FromBody] Comenzi prod)
        {
            try
            {
                if (prod == null)
                {
                    return BadRequest("The records are empty!");
                }
                else
                {
                    var createProd = await _comRepo.Create(prod);
                    return CreatedAtAction(nameof(GetProduse), new { id = createProd.Idcomanda }, createProd);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produse>> UpdateProd(int id, [FromBody] Comenzi prod)
        {
            try
            {
                if (id != prod.Idcomanda)
                {
                    return BadRequest("ID mismatch");
                }
                else
                {
                    await _comRepo.Update(prod);
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
            var prodToDelete = await _comRepo.GetById(id);
            if (prodToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await _comRepo.Delete(prodToDelete.Idcomanda);
                return NoContent();
            }
        }

    }
}
