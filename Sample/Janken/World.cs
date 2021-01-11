using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace AI.Sample.Janken
{
  /// <summary>
  /// world
  /// </summary>
  public class GenteiJankenWorld : World
  {
    int last = 1000;
    private JKResolver resolver;
    private readonly List<JankenAgent> Agents;
    //public List<JKAgent> Agents => jks;
    public GenteiJankenWorld(List<JankenAgent> jks)
    {
      this.Agents = jks;
      Console.WriteLine($"AGENTS={Agents.Count}");
      Init();
      handStatuses = new Dictionary<JankenAgent, JKHandStatus>();
      resolver = new JKResolver(this);
    }
    
    private readonly Dictionary<JankenAgent, JKHandStatus> handStatuses;

    public override List<Resource> initResources()
    {
      var result = new List<Resource>();

      foreach (JankenAgent agent in Agents)
      {
        result.AddRange(Enumerable.Range(0, 10).Select(i => new JKCard(agent, TypeJankenHand.G)));
        result.AddRange(Enumerable.Range(0, 10).Select(i => new JKCard(agent, TypeJankenHand.C)));
        result.AddRange(Enumerable.Range(0, 10).Select(i => new JKCard(agent, TypeJankenHand.P)));
        result.AddRange(Enumerable.Range(0, 3).Select(i => new JKCard(agent, TypeJankenHand.Pass)));

      }
      return result;
    }

    private JankenAgent RandomPick(JankenAgent exclude = null)
    {
      return Agents.Where(a =>
      {
        return exclude == null ? true : a != exclude;
      }).First();
    }

    private JKFight MakeRandomMatch()
    {
      JankenAgent A = RandomPick();
      JankenAgent B = RandomPick(A);
      return new JKFight(A, B);

    }

    public void Play()
    {
      //pickしよう
      MakeRandomMatch().Resolve(resolver);
      last--;
    }


    //使用済みカード（Pass以外）が全てOnだったら終了
    public override bool isContunue()
    {
      bool isLast = (0 < last);
      return isLast && this.Resources.Where(r => !r.Empty).Any();
    }

    public static GenteiJankenWorld From(int agentCount = 1000)
    {
      var agents = Enumerable.Range(0, agentCount).Select(i => new JankenAgent()).ToList();
      return new GenteiJankenWorld(agents);

    }
  }
}
