using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBDGuardPatrolState : BBDGuardState
{
    public override void EnterState(BBDGuards guard)
    {
        guard.Eyes.material=guard.yellowGlow;
    }

    public override void UpdateState(BBDGuards guard)
    {
        guard.agent.SetDestination(guard.target);
        if (guard.PlayerWithinRange())
        {
            guard.TransitionToState(guard.pursueState);
        }
    }
}
