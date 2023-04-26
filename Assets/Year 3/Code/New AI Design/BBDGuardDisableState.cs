using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBDGuardDisableState : BBDGuardState
{
    public override void EnterState(BBDGuards guard)
    {
        guard.agent.enabled = false;
        guard.canFire = false;
    }

    public override void UpdateState(BBDGuards guard)
    {
        
    }
}
