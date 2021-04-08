using System.Data;
using System;
using System.Collections.Generic;
using A_Knights_Tail.Models;
using Dapper;

namespace A_Knights_Tail.Repositories
{
   public class KnightsRepository
   {
      private readonly IDbConnection _db;

      public KnightsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<Knight> GetAll()
      {
         string sql = "SELECT * FROM knights;";
         return _db.Query<Knight>(sql);
      }

      internal Knight Create(Knight newKnight)
      {
         string sql = @"
         INSERT INTO knights
         (name, title, weapon, isAlive, castleId)
         VALUES
         (@name, @title, @weapon, @isAlive, @castleId);
         SELECT LAST_INSERT_ID();";
         int id = _db.ExecuteScalar<int>(sql, newKnight);
         newKnight.Id = id;
         return newKnight;
      }

      internal IEnumerable<Knight> getByCastleId(int id)
      {
         string sql = "SELECT * FROM  knights WHERE castleId = @id;";
         return _db.Query<Knight>(sql, new { id });
      }

      internal Knight Edit(Knight data)
      {
         string sql = @"
         UPDATE knights
         SET
            name = @Name,
            title = @Title,
            weapon = @Weapon,
            isAlive = @isAlive
         WHERE id = @Id;
         SELECT * FROM knights WHERE id = @Id;";
         return _db.QueryFirstOrDefault<Knight>(sql, data);
      }

      internal Knight GetById(int id)
      {
         string sql = "SELECT * FROM knights WHERE id = @id;";
         return _db.QueryFirstOrDefault<Knight>(sql, new { id });
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM knights WHERE id = @id LIMIT 1;";
         _db.Execute(sql, new { id });
      }
   }
}