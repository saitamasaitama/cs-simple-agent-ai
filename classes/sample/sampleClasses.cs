using System.Collections;
using System.Collections.Generic;
using System;

public class JankenHandResult : SignalOut
{
  public JankenAgent agent;
  public TypeJankenHand hand;
 
}


public class JankenDirection : SignalIn
{
  //挑戦者
  public readonly JankenAgent challenger;
  public JankenDirection(JankenAgent agent)
  {
    this.challenger = agent;
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





public class JankenAgent : Brain<
  JankenDirection,
  JankenHandResult,
  JankenEye,
  JankenHand,
  JankenComputer,
  TypeJankenHand,
  TypeSensorKey
  >
{

  
  public JankenAgent():base(
    sensor:new JankenEye()
    ,computer:new JankenComputer()
    ,actiator:new JankenHand()
    )
  {
  }
}

public class JankenHand : Actuator<JankenHandResult, TypeJankenHand>
{
  public Dictionary<TypeJankenHand, int> stock = new Dictionary<TypeJankenHand, int>{
    {TypeJankenHand.G,10},
    {TypeJankenHand.C,10},
    {TypeJankenHand.P,10},
    {TypeJankenHand.Pass,3}
  };


  public override JankenHandResult Send(TypeJankenHand key)
  {
    throw new NotImplementedException();
  }
}

public class JankenComputer : Computer<JankenDirection, JankenHandResult, JankenEye, TypeJankenHand, TypeSensorKey>
{
  public override Func<Actuator<JankenHandResult, TypeJankenHand>, JankenHandResult>
    Compute(JankenDirection sigin, JankenEye s)
  {

    return (act) => act.Send(TypeJankenHand.C);
    
  }


  public override TypeJankenHand DraftActuate()
  {
    //センサの情報などを総合して計算しよう
    throw new NotImplementedException();

  }
}

public class JankenEye : Sensor<TypeSensorKey>
{

}



