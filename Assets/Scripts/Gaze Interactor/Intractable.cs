using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intractable : MonoBehaviour, IRayIntractable
{
    [SerializeField] private float timer = 1;

    public float getTimer() => timer;

    public virtual void OnRayHit(float timer)
    {
        Debug.Log("GGG");
    }
    public virtual void OnRayExit()
    {
     //   throw new System.NotImplementedException();
    }
   
}
