using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymerModule : Module
{
    
    protected new void Start()
    {
        base.Start();
        this.effect = new PolymerEffect();
    }

}
