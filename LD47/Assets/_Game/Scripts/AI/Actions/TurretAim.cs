using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class TurretAim : Action
{
    public SharedTransform horizontalPivot;
    public SharedTransform verticalPivot;

    public SharedTransform target;

    public SharedVector3 targetOffset;

    public SharedVector3 horizontalRotationOffset;
    public SharedVector3 verticalRotationOffset;

    public bool idle = false;

    private Quaternion horizontalPivotRotation = Quaternion.identity;
    private Quaternion verticalPivotRotation = Quaternion.identity;

    public override void OnStart()
    {
        horizontalPivotRotation = horizontalPivot.Value.transform.localRotation;
        verticalPivotRotation = verticalPivot.Value.transform.localRotation;
    }

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

        horizontalPivotRotation = Quaternion.Slerp(horizontalPivotRotation, horizontalTarget * Quaternion.Euler(horizontalRotationOffset.Value), Time.fixedDeltaTime * 8.0f);
        verticalPivotRotation = Quaternion.Slerp(verticalPivotRotation, verticalTarget * Quaternion.Euler(verticalRotationOffset.Value), Time.fixedDeltaTime * 8.0f);
    }

    public override void OnLateUpdate()
    {
        horizontalPivot.Value.transform.localRotation = horizontalPivotRotation;
        verticalPivot.Value.transform.localRotation = verticalPivotRotation;
    }
}