using System;
namespace AI.Sample.Janken
{
  public class JKComputer : Computer<
    JankenActuator,
    JKSensorOut,
    TypeJankenHand,
    JKComputerOut>
  {
    protected override JKComputerOut doComputeActuate(JKSensorOut sensorOut)
    {
      return new JKComputerOut();
    }
  }
}
