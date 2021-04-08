using System;
using System.Collections.Generic;
using A_Knights_Tail.Models;
using A_Knights_Tail.Repositories;

namespace A_Knights_Tail.Services
{
   public class CastlesService
   {
      private readonly CastlesRepository _repo;

      public CastlesService(CastlesRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<Castle> GetAll()
      {
         return _repo.GetAll();
      }

      internal Castle GetById(int id)
      {
         Castle data = _repo.GetById(id);
         if (data == null)
         {
            throw new Exception("Invalid Id");
         }
         return data;
      }

      internal Castle Create(Castle newCastle)
      {
         return _repo.Create(newCastle);
      }

      internal Castle Edit(Castle updated)
      {
         Castle data = GetById(updated.Id);

         data.Name = updated.Name != null ? updated.Name : data.Name;
         data.Alliance = updated.Alliance != null ? updated.Alliance : data.Alliance;
         data.Lord = updated.Lord != null ? updated.Lord : data.Lord;

         return _repo.Edit(data);
      }

      internal String Delete(int id)
      {
         // NOTE: Why do we declare data? We don't use it...
         Castle data = GetById(id);
         _repo.Delete(id);
         return "delorted";
      }
   }
}