using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.diet.dtos;
using api.healthy.src.components.diet.services;
using Microsoft.AspNetCore.Mvc;

namespace api.healthy.src.components.diet.controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class DietController(IDietService ser) : ControllerBase
    {
        private readonly IDietService _ser = ser;

        [HttpPost("insertNewDiet/{userCpf:long}")]
        public async Task<ActionResult<DietModel>> InsertDiet(long userCpf, [FromBody] CreateDiet request) {
            try 
            {
                var diet = await _ser.InsertNewDiet(userCpf, request);
                return Ok(new {sucess = true, data = diet, dataCount = 1});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpGet("allAppDiets")]
        public async Task<ActionResult<List<DietModel>>> GetAllAppDiets() {
            try 
            {
                var diets = await _ser.GetAllAppDiets();
                return Ok(new {sucess = true, data = diets, dataCount = diets.Count});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpGet("getUserDiets/{userCpf:long}")]
        public async Task<ActionResult<List<DietModel>>> GetDietByCpf(long userCpf) {
            try 
            {
                var diets = await _ser.GetDietByCpf(userCpf);
                return Ok(new {sucess = true, data = diets, dataCount = diets.Count});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpPatch("fillBmr/{dietId:guid}")]
        public async Task<ActionResult<DietModel>> FillMbr(Guid dietId) 
        {
            try 
            {
                var diet = await _ser.FillBMR(dietId);
                return Ok(new {sucess = true, data = diet, dataCount = 1});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }
    }
}