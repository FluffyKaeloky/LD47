using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class TurretAim : Action
{
    public SharedTransform horizontalPivot;
    public SharedTransform verticalPivot;

    public SharedTransform target;

	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
        if (target == null)
            return TaskStatus.Failure;

        Vector3 targetVector = target.Value.position - transform.position;

        Quaternion q = Quaternion.LookRotation(targetVector);
        verticalPivot.Value.rotation = q;

		return TaskStatus.Running;
	}
}