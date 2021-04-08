using System.Data;
using System.Collections.Generic;
using System;
using A_Knights_Tail.Models;
using A_Knights_Tail.Repositories;

namespace A_Knights_Tail.Services
{
   public class KnightsService
   {
      private readonly KnightsRepository _repo;

      public KnightsService(KnightsRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<Knight> GetAll()
      {
         return _repo.GetAll();
      }

      internal Knight GetById(int id)
      {
         Knight data = _repo.GetById(id);
         if (data == null)
         {
            throw new Exception("Invalid Id");
         }
         return data;
      }

      internal IEnumerable<Knight> GetByCastleId(int id)
      {
         return _repo.getByCastleId(id);

      }


      internal Knight Create(Knight newKnight)
      {
         return _repo.Create(newKnight);
      }

      internal Knight Edit(Knight updated)
      {
         Knight data = GetById(updated.Id);
         data.Name = updated.Name != null ? updated.Name : data.Name;
         data.Title = updated.Title != null ? updated.Title : data.Title;
         data.Weapon = updated.Weapon != null ? updated.Weapon : data.Weapon;
         data.IsAlive = updated.IsAlive;
         return _repo.Edit(data);
      }

      internal string Delete(int id)
      {
         Knight data = GetById(id);
         _repo.Delete(id);
         return "delorted";
      }
   }
}