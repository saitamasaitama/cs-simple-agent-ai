using System;
namespace AI.Sample.Janken
{
  /// <summary>
  /// Agent。人間本体
  /// </summary>
  public class JankenAgent : Agent<
    JKSensor, JankenActuator, JKComputer,
    JankenDirection, TypeJankenHand,
    JKSensorOut, JKComputerOut>
  {
    protected override JankenActuator initActuator()
    {
      return new JankenActuator();
    }

    protected override JKComputer initComputer()
    {
      return new JKComputer();
    }

    protected override JKSensor initSensor()
    {
      return new JKSensor();
    }
  }
}
