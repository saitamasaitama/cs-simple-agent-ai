using System.Collections;
using System.Collections.Generic;
using System;

//センシング、コンピューティング、アクション

public abstract class Agent<SIG_IN, SIG_OUT, SENS, ACTI, COMP, AK, SK>
  where SIG_IN : SignalIn
  where SIG_OUT : SignalOut
  where SENS : Sensor<SK>
  where ACTI : Actuator<SIG_OUT, AK>
  where COMP : Computer<SIG_IN, SIG_OUT, SENS, AK, SK>
  where AK : Enum
  where SK : Enum
{

  public readonly SENS sensor;
  public readonly COMP computing;
  public readonly ACTI actuator;

  protected Agent(SENS sensor, COMP computer, ACTI actiator)
  {
    this.sensor = sensor;
    this.computing = computer;
    this.actuator = actiator;
  }

  /*
  public SIG_OUT Dispatch(SIG_IN sigin) =>
    computing.Compute(sigin,this.sensor)(this.actuator);
  */
  public SIG_OUT Dispatch(SIG_IN sigin)
  {
    return computing.Compute(sigin, this.sensor)(this.actuator);
  }


}

public abstract class Sensor<SK>
  where SK : Enum
{
}



//これは他のクラスからも参照されることも
public abstract class SignalOut
{
  protected virtual bool isTrue()
  {
    return true;
  }
  public static implicit operator bool(SignalOut s) => s.isTrue();
}

public abstract class SignalIn
{
  protected virtual bool isTrue()
  {
    return true;
  }
  public static implicit operator bool(SignalIn s) => s.isTrue();
}

public abstract class Computer<SIG_IN, SIG_OUT, SENS, AK, SK>
  where SIG_IN : SignalIn
  where SIG_OUT : SignalOut
  where SENS : Sensor<SK>
  where AK : Enum
  where SK : Enum
{
  /// <summary>
  /// コンピューターはアクチュエーターには単純なシグナルしか送ることはできず、
  /// アクチュエーターは入力からシグナルを生成する。
  /// </summary>
  /// <param name="sigin"></param>
  /// <param name="s"></param>
  /// <returns></returns>
  public abstract Func<Actuator<SIG_OUT, AK>, SIG_OUT> Compute(
    SIG_IN sigin, SENS s
  );
  //public virtual SIGOUT ComputeSignal(SENS sensor,AC)

  public abstract AK DraftActuate();
  private Memory memory;
}

public abstract class Memory
{

}

public abstract class Actuator<SIG_OUT, AK> : Dictionary<AK, Func<SIG_OUT>>
  where SIG_OUT : SignalOut
  where AK : Enum
{
  public abstract SIG_OUT Send(AK key);
}

public abstract class Resolver
{

}

public abstract class Condactor
{

}
