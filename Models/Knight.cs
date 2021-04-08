namespace A_Knights_Tail.Models
{
   public class Knight
   {
      public Knight()
      {
      }

      public int Id { get; set; }
      public int CastleId { get; set; }
      public string Name { get; set; }
      public string Title { get; set; }
      public string Weapon { get; set; }
      public bool IsAlive { get; set; }
   }
}