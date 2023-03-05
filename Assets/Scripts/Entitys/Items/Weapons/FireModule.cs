using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireModule : Module
{
    protected new void Start()
    {
        base.Start();
        this.effect = new FireEffect();
    }
}
