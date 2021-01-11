using System;
namespace AI.Sample.Janken
{

  /// <summary>
  /// シグナルOUT
  /// </summary>
  public class JKHandResult : SignalOut<JankenAgent>
  {
    public TypeJankenHand hand;
    public JKHandResult(JankenAgent o) : base(o)
    {
    }
  }

  /// <summary>
  /// SignalIn
  /// </summary>
  public class JankenDirection : SignalIn
  {
    //挑戦者
    public readonly JankenAgent challenger;
    public JankenDirection(JankenAgent agent)
    {
      this.challenger = agent;
    }
  }
}
