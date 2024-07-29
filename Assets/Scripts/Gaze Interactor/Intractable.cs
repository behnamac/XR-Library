using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Intractable : MonoBehaviour, IRayIntractable
{
    [SerializeField] private float timer = 1;

    public float getTimer() => timer;

    public virtual void OnRayHit()
    {

    }
    public virtual void OnRayExit()
    {
        //   throw new System.NotImplementedException();
    }


}
