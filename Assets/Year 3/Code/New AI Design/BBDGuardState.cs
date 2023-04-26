
using UnityEngine;

public abstract class BBDGuardState
{
    public abstract void EnterState(BBDGuards guard);
    public abstract void UpdateState(BBDGuards guard);
}
