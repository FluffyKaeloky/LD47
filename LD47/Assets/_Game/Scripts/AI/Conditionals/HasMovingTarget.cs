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
        //Rigidbodies
        List<Rigidbody> rigidbodies = Physics.OverlapSphere(transform.position, detectionRadius, int.MaxValue)
            .Select(x => x.GetComponentInParent<Rigidbody>())
            .Where(x => x != null)
            .Distinct()
            .Where(x => x.velocity.magnitude > triggerVelocity)
            .Where(x => HasLineOfSight(x.transform))
            .ToList();

        if (rigidbodies.Count > 0)
        {
            target.Value = rigidbodies[0].transform;
            return TaskStatus.Success;
        }

        //Player
        PlayerMovements player = Physics.OverlapSphere(transform.position, detectionRadius, 1 << LayerMask.NameToLayer("Player"), QueryTriggerInteraction.Ignore)
            .Select(x => x.GetComponentInParent<PlayerMovements>())
            .Where(x => x != null)
            .Distinct()
            .Where(x => HasLineOfSight(x.transform))
            .FirstOrDefault();

        if (player != null)
        {
            if (!player.IsWalking && (Mathf.Abs(player.Vertical) > 0.5f || Mathf.Abs(player.Horizontal) > 0.5f))
            {
                target.Value = player.transform;
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
	}

    public bool HasLineOfSight(Transform t)
    {
        Ray ray = new Ray(transform.position, (t.position - transform.position).normalized);
        RaycastHit hit;

        float distance = Vector3.Distance(t.position, transform.position);

        if (Physics.Raycast(ray, out hit, distance, int.MaxValue, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.transform.IsChildOf(t))
                return true;
        }

        return false;
    }
}