using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class TurretWeaponSetState : Action
{
    public bool firingState = true;

    public SharedTurretWeapon weapon = null;

    public SharedTransform forcedTarget = null;

    public override TaskStatus OnUpdate()
    {
        if (weapon == null)
            return TaskStatus.Failure;

        if (firingState == true && forcedTarget.Value != null)
            weapon.Value.SetTarget(forcedTarget.Value);

        weapon.Value.SetState(firingState);

        return TaskStatus.Success;
    }
}
