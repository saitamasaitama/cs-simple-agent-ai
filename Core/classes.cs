using System;
namespace AI.Core
{
  using System.Collections;
  using System.Collections.Generic;
  using System;
  using System.Linq;

  //センシング、コンピューティング、アクション

  /// <summary>
  /// ワールドに出力するシグナル
  /// </summary>
  /// <typeparam name="AGENT"></typeparam>
  public abstract class SignalOut<AGENT>
  {
    public AGENT origin;
    public SignalOut(AGENT origin)
    {
      this.origin = origin;
    }
  }

  /// <summary>
  /// ワールドから入力に使うシグナル
  /// </summary>
  public abstract class SignalIn
  {
  }


  /// <summary>
  /// シグナル基本クラス
  /// </summary>
  /// <typeparam name="SIG_IN"></typeparam>
  /// <typeparam name="SIG_OUT"></typeparam>
  /// <typeparam name="AGENT"></typeparam>
  public interface SignalIO<SIG_IN, SIG_OUT, AGENT>
    where SIG_IN : SignalIn
    where SIG_OUT : SignalOut<AGENT>
  {
    SIG_OUT Input(SIG_IN sig_in);
    void Push(SIG_IN sig_in);
    SIG_OUT Pull();
    void Buff(SIG_OUT data);
  }

  /// <summary>
  /// シグナル中間者
  /// </summary>
  /// <typeparam name="SIG_IN"></typeparam>
  /// <typeparam name="SIG_OUT"></typeparam>
  /// <typeparam name="AGENT"></typeparam>
  public abstract class SignalController<SIG_IN, SIG_OUT, AGENT>
    : SignalIO<SIG_IN, SIG_OUT, AGENT>
    where SIG_IN : SignalIn
    where SIG_OUT : SignalOut<AGENT>
  {

    public AGENT Agent => agent;
    private AGENT agent;
    private SIG_OUT buff;
    protected abstract SIG_OUT Dispatch(SIG_IN input, AGENT agent);

    public SIG_OUT SendAgent(AGENT agent, SIG_IN sig)
    {
      this.agent = agent;
      return this.Input(sig);
    }

    public SIG_OUT Input(SIG_IN sig_in)
    {
      Push(sig_in);
      return Pull();
    }
    public void Buff(SIG_OUT data)
    {
      this.buff = data;
    }
    public SIG_OUT Pull()
    {
      return buff;
    }
    public void Push(SIG_IN sig_in)
    {
      Buff(Dispatch(sig_in, Agent));
    }

  }

  /// <summary>
  /// センサはどうしよう
  /// </summary>
  public abstract class Sensor<CONTROL_IN, SOUT>
  {
    public abstract SOUT Sense(CONTROL_IN tin);
  }


  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="SENSOR"></typeparam>
  /// <typeparam name="ACTUATOR"></typeparam>
  /// <typeparam name="COMPUTER"></typeparam>
  public abstract class Agent<
    SENSOR, ACTUATOR, COMPUTER,
    CONTROL_IN, CONTROL_OUT,
    SENSOR_OUT, ACTUATOR_IN>
    where SENSOR : Sensor<CONTROL_IN, SENSOR_OUT>
    where ACTUATOR : Actuator<ACTUATOR_IN, CONTROL_OUT>
    where COMPUTER : Computer<ACTUATOR, SENSOR_OUT, CONTROL_OUT, ACTUATOR_IN>
  {
    private readonly SENSOR sensor;
    private readonly ACTUATOR actuator;
    private readonly COMPUTER computer;
    protected abstract SENSOR initSensor();
    protected abstract ACTUATOR initActuator();
    protected abstract COMPUTER initComputer();

    public Agent()
    {
      this.sensor = initSensor();
      this.actuator = initActuator();
      this.computer = initComputer();
    }

    public CONTROL_OUT Request(CONTROL_IN controlIn)
    {
      return this.computer.Compute(sensor.Sense(controlIn), actuator);
    }

  }

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="SENS"></typeparam>
  /// <typeparam name="ACTU"></typeparam>
  public abstract class Computer<
    ACTU,
    SENSOR_OUT,
    CONTROL_OUT,
    ACTUATOR_IN>
    where ACTU : Actuator<ACTUATOR_IN, CONTROL_OUT>
  {
    public CONTROL_OUT Compute(SENSOR_OUT sensorOut, ACTU actuator)
    {
      return actuator.Actuate(doComputeActuate(sensorOut));
    }

    protected abstract ACTUATOR_IN doComputeActuate(SENSOR_OUT sensorOut);
  }

  /// <summary>
  /// 
  /// </summary>
  public abstract class Actuator<ACTUATOR_IN, CONTROL_OUT>
  {
    public abstract CONTROL_OUT Actuate(ACTUATOR_IN tin);
  }



  /// <summary>
  /// 
  /// </summary>
  public abstract class Memory
  {

  }

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="CONTROL_OUT"></typeparam>
  /// <typeparam name="AGENT"></typeparam>
  /// <typeparam name="WORLD"></typeparam>
  public abstract class Resolver<CONTROL_OUT, AGENT, WORLD> : Stack<CONTROL_OUT>
    where WORLD : World
    where CONTROL_OUT : SignalOut<AGENT>
  {
    private WORLD world;
    public Resolver(WORLD world)
    {
      this.world = world;
    }

    public event Action OnResolved;
    public void Send(CONTROL_OUT sig)
    {
      this.Push(sig);
      if (isResolvable())
      {
        while (0 < this.Count)
        {
          ResolveSingle(this.Pop(), this.world);
        }
        OnResolved();
      }
    }
    protected abstract void ResolveSingle(CONTROL_OUT sigout, WORLD world);
    //現状解決しているか
    protected abstract bool isResolvable();
  }

  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="SIG"></typeparam>
  /// <typeparam name="AGENT"></typeparam>
  /// <typeparam name="RESOLVER"></typeparam>
  /// <typeparam name="WORLD"></typeparam>
  public abstract class Fight<SIG, AGENT, RESOLVER, WORLD>
    where WORLD : World
    where SIG : SignalOut<AGENT>
    where RESOLVER : Resolver<SIG, AGENT, WORLD>
  {
    public readonly AGENT A;
    public readonly AGENT B;
    public Fight(AGENT a, AGENT b)
    {
      this.A = a;
      this.B = b;
    }
    public abstract void Resolve(RESOLVER resolver);

  }

  /// <summary>
  /// 
  /// </summary>
  public abstract class Resource
  {
    public abstract bool Use();
    public bool Empty => isEmpty();
    protected abstract bool isEmpty();
  }

  /// <summary>
  /// World
  /// </summary>
  public abstract class World
  {
    public bool Continue => isContunue();
    public List<Resource> Resources => resources;
    private List<Resource> resources;
    public abstract bool isContunue();

    public void Init()
    {
      resources = initResources();
    }

    public abstract List<Resource> initResources();


  }




}
