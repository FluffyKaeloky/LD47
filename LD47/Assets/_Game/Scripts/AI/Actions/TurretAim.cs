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
            Vector3 targetDir = (target.Value.position - transform.position).normalized;
            Vector3 horizontalTargetDir = Vector3.ProjectOnPlane(targetDir, Vector3.up).normalized;
            Vector3 verticalTargetDir = Vector3.ProjectOnPlane(targetDir, Vector3.Cross(targetDir, Vector3.up).normalized).normalized;

            Debug.DrawLine(transform.position, transform.position + Vector3.Cross(targetDir, Vector3.up).normalized * 2.0f, Color.cyan);
            Debug.DrawLine(transform.position, transform.position + horizontalTargetDir * 2.0f, Color.blue);
            Debug.DrawLine(transform.position, transform.position + verticalTargetDir * 2.0f, Color.red);

            Quaternion originalHorizontalLocalRotation = horizontalPivot.Value.transform.localRotation;
            horizontalPivot.Value.LookAt(horizontalPivot.Value.position + horizontalTargetDir, -transform.up);
            horizontalTarget = horizontalPivot.Value.localRotation;

            Quaternion originalVerticalLocalRotation = verticalPivot.Value.transform.localRotation;
            verticalPivot.Value.LookAt(verticalPivot.Value.position + verticalTargetDir, -transform.up);
            verticalTarget = verticalPivot.Value.localRotation;

            horizontalPivot.Value.localRotation = originalHorizontalLocalRotation;
            verticalPivot.Value.localRotation = originalVerticalLocalRotation;
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