using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using task.Data;
using task.Data.GameRepo;
using task.Dtos;
using task.Entities;
using task.Helpers;

namespace task.Controllers
{   
    [ApiController]
    [Route("/")]
    public class GameController:BaseController
    {
       private readonly IUnitOfWork _uniteOfwork ;
       

        public GameController(IUnitOfWork uniteOfwork)
        {
            _uniteOfwork = uniteOfwork;
        }

        [HttpGet("select_top_by_playtime")]
        public async Task<ActionResult<IEnumerable<Object>>> findAll([FromQuery] GameParams gameParams){

            return Ok(await _uniteOfwork.gameRepository.findAll(gameParams));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>>  findById(int id){
            var game  = await _uniteOfwork.gameRepository.findById(id);
            if(game ==null) return NotFound();

            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<Game>> addNewGame([FromBody] Game game){
            try
            {
                return Ok(await _uniteOfwork.gameRepository.addGame(game));
            }
            catch (Exception ex)
            {
              return  BadRequest(ex.Message);
            }
            
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteGameById(int id)
        {
            Game game  = await _uniteOfwork.gameRepository.findById(id);
            if(game == null) return NotFound();

            await _uniteOfwork.gameRepository.DeleteGame(game);
            
            if(! await _uniteOfwork.Complete()) return BadRequest();
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Game>> updateGame([FromBody] GameDto gameDto,int id)
        {   
            var game =await _uniteOfwork.gameRepository.findById(id);
            if(game ==null) return NotFound();
            game.userId = gameDto.userId;
            game.game =gameDto.game;
            game.playTime =gameDto.playTime;
            game.genre = gameDto.genre;
            game.platforms = gameDto.platforms;

            if(await _uniteOfwork.Complete()) return Ok(game);
            return BadRequest();
        }
        
    }
}