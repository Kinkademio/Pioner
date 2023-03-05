using UnityEngine;

public class Building : WorldEntity
{
    [SerializeField] bool isInvulnerable = false;
   
    protected new void Start()
    {
        base.Start();
        this.SetBeAffectedByEffect(!this.isInvulnerable);
    }

}
