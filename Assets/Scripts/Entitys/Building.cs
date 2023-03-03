using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : WorldEntity
{
    [SerializeField] bool isInvulnerable = false;
   
    void Start()
    {
        this.SetBeAffectedByEffect(!this.isInvulnerable);
        Debug.Log(this.GetBeAffectedByEffect());
        this.SetHealth(5);
          
            Effect fire = new FireEffect();
            Effect poymer = new PolymerEffect();

            this.ImposedByEffect(fire);
            this.ImposedByEffect(poymer);
      
    }

}
