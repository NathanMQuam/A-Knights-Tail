using System;
using Microsoft.AspNetCore.Mvc;
using A_Knights_Tail.Services;
using A_Knights_Tail.Models;
using System.Collections.Generic;

namespace A_Knights_Tail.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class KnightsController : ControllerBase
   {
      private readonly KnightsService _service;

      public KnightsController(KnightsService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<Knight> Get()
      {
         try
         {
            return Ok(_service.GetAll());
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("{id}")]
      public ActionResult<Knight> GetAll(int id)
      {
         try
         {
            return Ok(_service.GetById(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPost]
      public ActionResult<Knight> Create([FromBody] Knight newKnight)
      {
         try
         {
            return Ok(_service.Create(newKnight));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<Knight> EditKnight([FromBody] Knight updated, int id)
      {
         try
         {
            updated.Id = id;
            return Ok(_service.Edit(updated));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<Knight> Delete(int id)
      {
         try
         {
            return Ok(_service.Delete(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}