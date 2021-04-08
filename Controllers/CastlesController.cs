using System;
using Microsoft.AspNetCore.Mvc;
using A_Knights_Tail.Services;
using A_Knights_Tail.Models;
using System.Collections.Generic;

namespace A_Knights_Tail.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CastlesController : ControllerBase
   {
      private readonly CastlesService _service;
      private readonly KnightsService _ks;

      public CastlesController(CastlesService service, KnightsService ks)
      {
         _service = service;
         _ks = ks;
      }

      [HttpGet]
      public ActionResult<Castle> Get()
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
      public ActionResult<Castle> GetAll(int id)
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
      public ActionResult<Castle> Create([FromBody] Castle newCastle)
      {
         try
         {
            return Ok(_service.Create(newCastle));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<Castle> EditCastle([FromBody] Castle updated, int id)
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
      public ActionResult<Castle> Delete(int id)
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

      [HttpGet("{id}/knights")]
      public ActionResult<IEnumerable<Knight>> GetKnights(int id)
      {
         try
         {
            return Ok(_ks.GetByCastleId(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}