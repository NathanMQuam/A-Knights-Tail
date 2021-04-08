using System.Data;
using System;
using System.Collections.Generic;
using A_Knights_Tail.Models;
using Dapper;

namespace A_Knights_Tail.Repositories
{
   public class CastlesRepository
   {
      private readonly IDbConnection _db;

      public CastlesRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<Castle> GetAll()
      {
         string sql = "SELECT * FROM castles;";
         return _db.Query<Castle>(sql);
      }

      internal Castle GetById(int id)
      {
         string sql = "SELECT * FROM castles WHERE id = @id;";
         return _db.QueryFirstOrDefault<Castle>(sql, new { id });
      }

      internal Castle Create(Castle newCastle)
      {
         string sql = @"
         INSERT INTO castles
         (name, alliance, lord)
         VALUES
         (@name, @alliance, @lord);";
         int id = _db.ExecuteScalar<int>(sql, newCastle);
         newCastle.Id = id;
         return newCastle;
      }

      internal Castle Edit(Castle data)
      {
         string sql = @"
         UPDATE castles
         SET
            name = @name,
            alliance = @alliance,
            lord = @lord
         WHERE id = @id;
         SELECT * FROM castles WHERE id = @id;";
         Castle returnCastle = _db.QueryFirstOrDefault<Castle>(sql, data);
         return returnCastle;
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM castles WHERE Id = @id LIMIT 1";
         _db.Execute(sql, new { id });
      }
   }
}