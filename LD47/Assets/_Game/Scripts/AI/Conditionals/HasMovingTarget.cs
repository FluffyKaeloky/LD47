using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections.Generic;
using System.Linq;

public class HasMovingTarget : Conditional
{
    public float detectionRadius = 10.0f;
    public float triggerVelocity = 1.0f;

    public SharedTransform target;

	public override TaskStatus OnUpdate()
	{
        List<Rigidbody> rigidbodies = Physics.OverlapSphere(transform.position, detectionRadius, int.MaxValue)
            .Select(x => x.GetComponentInParent<Rigidbody>())
            .Where(x => x != null)
            .Distinct()
            .Where(x => x.velocity.magnitude > triggerVelocity)
            .ToList();

        if (rigidbodies.Count > 0)
        {
            target = rigidbodies[0].transform;
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
	}
}