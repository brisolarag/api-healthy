using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.healthy.src.components.users.dtos;
using api.healthy.src.components.users.services;
using Microsoft.AspNetCore.Mvc;

namespace api.healthy.src.components.users.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService ser) : ControllerBase
    {
        private readonly IUserService _ser = ser;

        [HttpGet("allUsers")]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            try
            {
                var users = await _ser.GetUsersAsync();
                return Ok(new {sucess = true, data = users, dataCount = users.Count});
            } catch (Exception ex) {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
            
        }

        [HttpGet("cpfSearch")]
        public async Task<ActionResult<UserModel>> GetUserByCpf(long cpf) {
            try
            {
                var user = await _ser.GetUserByCpfAsync(cpf);
                return Ok(new {sucess = true, data = user, dataCount = 1});
            }
            catch (Exception ex)
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpGet("filterSearch")]
        public async Task<ActionResult<List<UserModel>>> GetUserSearch(string? fname, string? email, char? sex) {
            try 
            {
                var users = await _ser.GetUserAsync(fname, email, sex);
                return Ok(new {sucess = true, data = users, dataCount = users.Count});
            } catch (Exception ex) {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpPost("newUser")]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] NewUser request) {
            try 
            {
                var user = await _ser.CreateUser(request);
                return Ok(new {sucess = true, data = user, dataCount = 1});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpPatch("updateUser/{userCpf:long}")]
        public async Task<ActionResult<UserModel>> UpdateUser(long userCpf, EditUser request) {
            try
            {
                var user = await _ser.UpdateUser(userCpf, request);
                return Ok(new {sucess = true, data = user, dataCount = 1});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }

        [HttpDelete("deleteUser/{userCpf:long}")]
        public async Task<ActionResult<UserModel>> DeleteUser(long userCpf) {
            try 
            {
                var user = await _ser.DeleteUser(userCpf);
                return Ok(new {sucess = true, data= user, dataCount = 1});
            } catch (Exception ex) 
            {
                return BadRequest(new {sucess = false, ex = ex.Message, dataCount = -1});
            }
        }


    }   
}