using System;
namespace AI.Sample.Janken
{
  public class JKSensor : Sensor<JankenDirection, JKSensorOut>
  {
    public override JKSensorOut Sense(JankenDirection tin)
    {
      //ここに処理を書く

      return new JKSensorOut();

    }
  }
}
