using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretWeapon : MonoBehaviour
{
    public float fireRate = 0.15f;
    public float damages = 1.0f;

    public float pushback = 0.1f;

    public float spread = 3.0f;

    public float maxDistance = 50.0f;

    public Transform fireMuzzle = null;

    public UnityEvent onStartFire = new UnityEvent();
    public UnityEvent onBulletFired = new UnityEvent();
    public UnityEvent onEndFire = new UnityEvent();

    private Coroutine fireCoroutine = null;

    private bool isFiring = false;

    private Transform forcedTarget = null;

    public void SetState(bool firing)
    {
        if (firing)
        {
            if (isFiring)
                return;

            fireCoroutine = StartCoroutine(FireLoop());
            isFiring = true;

            onStartFire?.Invoke();
        }
        else
        {
            if (!isFiring)
                return;

            if (fireCoroutine != null)
                StopCoroutine(fireCoroutine);
            fireCoroutine = null;

            isFiring = false;
            forcedTarget = null;

            onEndFire?.Invoke();
        }
    }

    public void SetTarget(Transform target)
    {
        forcedTarget = target;
    }

    private void Update()
    {
        Debug.DrawLine(fireMuzzle.position, fireMuzzle.forward * 50.0f, Color.magenta);
    }

    private IEnumerator FireLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            float spreadExtent = spread * 0.5f;

            Vector3 direction = forcedTarget != null ? (forcedTarget.position - fireMuzzle.position).normalized : fireMuzzle.forward;

            Ray ray = new Ray(fireMuzzle.position, 
                Quaternion.AngleAxis(Random.Range(-spreadExtent, spreadExtent), fireMuzzle.right) *
                Quaternion.AngleAxis(Random.Range(-spreadExtent, spreadExtent), fireMuzzle.up) *
                direction);

            RaycastHit hit;

            Vector3 target = Vector3.zero;

            if (Physics.Raycast(ray, out hit, maxDistance, int.MaxValue, QueryTriggerInteraction.Ignore))
            {
                target = hit.point;
                Rigidbody targetRb = hit.collider.attachedRigidbody;
                if (targetRb != null)
                    targetRb.AddForceAtPosition(ray.direction * pushback, hit.point, ForceMode.Impulse);

                Damageable damageable = hit.collider.GetComponentInParent<Damageable>();
                if (damageable != null)
                    damageable.TakeDamage(damages);
            }
            else
                target = fireMuzzle.position + fireMuzzle.forward * maxDistance;

            Debug.DrawLine(ray.origin, target, Color.yellow, 0.1f);

            //TODO : Use target for VFX ?

            onBulletFired?.Invoke();
        }
    }
}
