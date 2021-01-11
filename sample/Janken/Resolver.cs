using System;
using System.Collections;
using System.Collections.Generic;

namespace AI.Sample.Janken
{
  /// <summary>
  /// Resolver
  /// </summary>
  public class JKResolver : Resolver<JKHandResult, JankenAgent, GenteiJankenWorld>
  {
    public JKResolver(GenteiJankenWorld w) : base(w)
    {
      this.OnResolved += JKResolver_OnResolved;
    }

    private void JKResolver_OnResolved()
    {
      Console.WriteLine("Resolved!");

    }

    protected override bool isResolvable()
    {
      return 2 == this.Count;
    }


    protected override void ResolveSingle(JKHandResult sigout, GenteiJankenWorld world)
    {
      throw new NotImplementedException();
    }
  }
}
