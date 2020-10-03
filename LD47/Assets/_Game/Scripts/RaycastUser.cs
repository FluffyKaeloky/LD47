using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class RaycastUser : UserControl
{
    public float useDistance = 1.0f;

    private PlayerInput playerInput = null;

    private Usable hoveredUsable = null;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        playerInput.onUseUp.AddListener(UseUp);
        playerInput.onUseDown.AddListener(UseDown);
        playerInput.onThrowUp.AddListener(UseAltUp);
        playerInput.onThrowDown.AddListener(UseAltDown);
    }

    private void OnDestroy()
    {
        playerInput?.onUseUp.RemoveListener(UseUp);
        playerInput?.onUseDown.RemoveListener(UseDown);
        playerInput?.onThrowUp.RemoveListener(UseAltUp);
        playerInput?.onThrowDown.RemoveListener(UseAltDown);
    }

    private async void FixedUpdate()
    {
        await new WaitForEndOfFrame();

        Ray ray = new Ray(playerInput.camera.transform.position, playerInput.camera.transform.forward);

        List<RaycastHit> hits = Physics.RaycastAll(ray, useDistance, int.MaxValue, QueryTriggerInteraction.Ignore).OrderBy(x => x.distance).ToList();

        foreach (RaycastHit hit in hits)
        {
            //Hit self. Continue.
            if (hit.collider.transform.IsChildOf(transform))
                continue;

            Usable usable = hit.collider.GetComponentInParent<Usable>();
            if (usable != null)
            {
                if (usable != hoveredUsable)
                {
                    hoveredUsable?.HoverLeave(this);
                    hoveredUsable = usable;
                    hoveredUsable.HoverEnter(this);
                    break;
                }
                else if (usable == hoveredUsable)
                    return;
            }
            else
            {
                hoveredUsable?.HoverLeave(this);
                hoveredUsable = null;
                break;
            }
        }

        if (hits.Count == 0 && hoveredUsable != null)
        {
            hoveredUsable.HoverLeave(this);
            hoveredUsable = null;
        }
    }

    public override void UseUp() => hoveredUsable?.MouseUp(this);
    public override void UseDown() => hoveredUsable?.MouseDown(this);

    public override void UseAltUp() => hoveredUsable?.MouseAltUp(this);
    public override void UseAltDown() => hoveredUsable?.MouseAltDown(this);

    private void OnDrawGizmosSelected()
    {
        if (playerInput == null)
            playerInput = GetComponent<PlayerInput>();

        if (playerInput != null && playerInput.camera != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(playerInput.camera.transform.position, playerInput.camera.transform.position + playerInput.camera.transform.forward * useDistance);

            Ray ray = new Ray(playerInput.camera.transform.position, playerInput.camera.transform.forward);

            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * useDistance);
        }
    }
}
