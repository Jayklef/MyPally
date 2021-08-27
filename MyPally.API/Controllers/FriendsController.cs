using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPally.DataAccess.Dtos;
using MyPally.DataAccess.Repositories.Interface;
using MyPally.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPally.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private IFriendRepository _IFriendRepository;
        public FriendsController(IFriendRepository IFriendRepository)
        {
            _IFriendRepository = IFriendRepository;
        }

        [HttpGet("GetAllFriends")]
        public IActionResult GetAllFriends()
        {
            try
            {
                var friends = _IFriendRepository.GetAllFriends();
                return Ok(friends);
            }
            catch(Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("GetFriendById")]
        public IActionResult GetFriendById(int id)
        {
            try
            {
                var friend = _IFriendRepository.GetFriendById(id);
                return Ok(friend);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPost("CreateFriend")]
        public IActionResult CreateFriend(FriendDto friendDto)
        {
            try
            {
                _IFriendRepository.CreateFriend(friendDto);
                return Ok(friendDto);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };
                return BadRequest(errorResponse);
            }           
        }

        [HttpPut("UpdateFriend")]
        public IActionResult UpdateFriend(FriendDto friendDto)
        {
            try
            {
                _IFriendRepository.UpdateFriend(friendDto);
                return Ok(friendDto);
            }

            catch (Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("DeleteFriend")]
        public IActionResult DeleteFriend(int id)
        {
            try
            {
                _IFriendRepository.DeleteFriend(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };
                return BadRequest(errorResponse);
            }
        }
    }
}
