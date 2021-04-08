using Microsoft.AspNetCore.Mvc;

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
   }
}