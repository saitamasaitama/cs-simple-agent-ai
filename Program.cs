using System;
using System.Linq;

namespace AI.Sample
{
  class Program
  {
    static void Main(string[] args)
    {


      Janken.GenteiJankenWorld gtjk = Janken.GenteiJankenWorld.From(1000);

      var rand = new Random();
      //場の継続が可能かどうか
      Console.WriteLine("BEGIN GAME!");
      while (gtjk.Continue)
      {
        gtjk.Play();
      }
      Console.WriteLine("END GAME!");
    }
  }
}
