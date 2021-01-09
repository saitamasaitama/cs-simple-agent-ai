using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace AI
{
  class Program
  {
    static void Main(string[] args)
    {
      var agents= Enumerable.Range(0, 1_000).Select(i => new JankenAgent()).ToList();
      var rand = new Random();
      Func<bool> func = () => agents.Where(agent =>agent.actuator.stock.Where(kv=>0<kv.Value).Any()).Any();

      Func<JankenAgent> pickA = () => agents.Where(
        agent =>agent.actuator.stock.Where(kv => 0 < kv.Value).Any()
      ).OrderBy(o=>rand.NextDouble())
      .First()
      ;
      Func<JankenAgent,JankenAgent> pickB = A => agents.Where(
        agent => agent!=A && agent.actuator.stock.Where(kv => 0 < kv.Value).Any()
      ).OrderBy(o => rand.NextDouble())
      .First()
      ;

      while (func())
      {
        JankenAgent a = pickA();
        JankenAgent b = pickB(a);        
        JankenDirection directionA = new JankenDirection(b);
        JankenDirection directionB = new JankenDirection(a);

        JankenHandResult resultA =a.Dispatch(directionA);
        JankenHandResult resultB = b.Dispatch(directionB);

        // リゾルブ


      }



      

      
      Console.WriteLine("Hello World!");
    }
  }
}
