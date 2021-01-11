using System;
namespace AI.Sample.Janken
{
  /// <summary>
  /// Resource
  /// </summary>
  public class JKCard : Resource
  {
    public JKCard(JankenAgent owner, TypeJankenHand hand)
    {
      this.owner = owner;
      type = hand;
    }

    public readonly JankenAgent owner;
    public readonly TypeJankenHand type;

    private bool used = false;
    public override bool Use()
    {
      if (used) return false;
      used = true;
      return true;
    }

    protected override bool isEmpty()
    {
      if (type == TypeJankenHand.Pass) return true;
      return this.used;
    }
  }
}
