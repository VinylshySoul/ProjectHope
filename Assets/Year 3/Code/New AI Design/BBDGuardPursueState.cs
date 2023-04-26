using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBDGuardPursueState : BBDGuardState
{
    public override void EnterState(BBDGuards guard)
    {
       guard.Eyes.material=guard.redGlow;
    }

    public override void UpdateState(BBDGuards guard)
    {
        guard.target = guard.player.position;
        guard.agent.SetDestination(guard.target);

        if (!guard.PlayerWithinRange())
        {
            guard.SetNextTarget();
            guard.TransitionToState(guard.patrolState);
        }
    }
}
