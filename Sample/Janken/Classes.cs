using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace AI.Sample.Janken
{
  /// <summary>
  /// ステータス
  /// </summary>
  public class JKHandStatus : Dictionary<TypeJankenHand, int>
  {
    public static JKHandStatus From(JankenAgent agent, List<JKCard> d)
    {
      var result = new JKHandStatus();
      result.Add(TypeJankenHand.C, d.Where(c => c.owner == agent && c.type == TypeJankenHand.C).Count());
      result.Add(TypeJankenHand.G, d.Where(c => c.owner == agent && c.type == TypeJankenHand.G).Count());
      result.Add(TypeJankenHand.P, d.Where(c => c.owner == agent && c.type == TypeJankenHand.P).Count());
      result.Add(TypeJankenHand.Pass, d.Where(c => c.owner == agent && c.type == TypeJankenHand.Pass).Count());

      return result;
    }
  }


  /*
   サンプルAI - じゃんけん大会
   */
  public enum TypeJankenHand
  {
    G,
    C,
    P,
    Pass,
  }

  public enum TypeSensorKey
  {
    ENEMY_HAND,
    MY_HAND
  }
}
