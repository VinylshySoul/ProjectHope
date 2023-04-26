using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBDGuardFireState : BBDGuardState
{
    private float nextCheck;
    public override void EnterState(BBDGuards guard)
    {
        nextCheck = Time.time + guard.distanceCheckFrequency;
    }

    public override void UpdateState(BBDGuards guard)
    {
        if (guard.canFire)
        {
            if (Time.time > nextCheck)
            {
                guard.FireBullet();
                nextCheck = Time.time + guard.distanceCheckFrequency;
            }
        }
        
        if (!guard.PlayerWithinRange())
        {
            guard.TransitionToState(guard.patrolState);
        }
    }
}
