using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System;
using System.Diagnostics;
/*
public class Agent : MonoBehaviour
{
  private Stopwatch stopwatch=new Stopwatch();
  public DateTime now;
  public string s;
  public bool alive=true;
  public int sec = 0;

  private void Awake()
  {
    now = DateTime.Now;
    
  }
  // Start is called before the first frame update
  IEnumerator Start()
  {
    while (alive)
    {
      stopwatch.Restart();
      //処理実行
      Tick();
      yield return new WaitForSecondsRealtime((float)(1.0-stopwatch.Elapsed.TotalSeconds));
    }
    yield break;
  }

  // Update is called once per frame
  void Tick()
  {
    now += TimeSpan.FromSeconds(1);
    s = now.ToLongTimeString();
  }
}
*/