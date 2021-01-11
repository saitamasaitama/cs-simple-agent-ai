using System;
namespace AI.Sample.Janken
{
  /// <summary>
  /// fight
  /// </summary>
  public class JKFight : Fight<JKHandResult, JankenAgent, JKResolver, GenteiJankenWorld>
  {
    public JKFight(JankenAgent a, JankenAgent b) : base(a, b)
    {
    }

    public override void Resolve(JKResolver resolver)
    {
      JKController signaler = new JKController();
      JankenDirection directionToA = new JankenDirection(B);
      JankenDirection directionToB = new JankenDirection(A);
      resolver.Send(signaler.SendAgent(A, directionToA));
      resolver.Send(signaler.SendAgent(B, directionToB));
    }
  }
}
