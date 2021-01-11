using System;
namespace AI.Sample.Janken
{
  //signaler <--> agent
  public class JKController : SignalController<
    JankenDirection,
    JKHandResult,
    JankenAgent
    >
  {
    protected override JKHandResult Dispatch(
      JankenDirection input,
      JankenAgent agent)
    {
      var result = new JKHandResult(agent);
      result.hand = agent.Request(input);
      //agent  think
      return result;
    }
  }
}
