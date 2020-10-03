using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class TurretAim : Action
{
    public SharedTransform horizontalPivot;
    public SharedTransform verticalPivot;

    public SharedTransform target;

    public SharedVector3 targetOffset;

    public bool idle = false;

	public override TaskStatus OnUpdate()
	{
        if (target.Value == null && idle == false)
            return TaskStatus.Failure;

		return TaskStatus.Running;
	}

    public override void OnFixedUpdate()
    {
        Quaternion horizontalTarget = Quaternion.identity;
        Quaternion verticalTarget = Quaternion.identity;

        if (!idle)
        {
            Vector3 targetEuler = Quaternion.LookRotation((target.Value.position + targetOffset.Value - transform.position).normalized, transform.up).eulerAngles;

            horizontalTarget = Quaternion.AngleAxis(targetEuler.y - 180.0f, transform.up);
            verticalTarget = Quaternion.AngleAxis(targetEuler.x, -transform.right) * Quaternion.AngleAxis(targetEuler.z, transform.forward);
        }

        horizontalPivot.Value.transform.localRotation = Quaternion.Slerp(horizontalPivot.Value.transform.localRotation, horizontalTarget, Time.fixedDeltaTime * 8.0f);
        verticalPivot.Value.transform.localRotation = Quaternion.Slerp(verticalPivot.Value.transform.localRotation, verticalTarget, Time.fixedDeltaTime * 8.0f);
    }
}