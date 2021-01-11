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
      throw new NotImplementedException();
    }

    protected override JKComputer initComputer()
    {
      throw new NotImplementedException();
    }

    protected override JKSensor initSensor()
    {
      throw new NotImplementedException();
    }
  }
}
