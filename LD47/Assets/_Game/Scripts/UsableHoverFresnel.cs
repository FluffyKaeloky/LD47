using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Usable))]
public class UsableHoverFresnel : MonoBehaviour
{
    public bool autoSetRenderer = true;

    [HideIf("autoSetRenderer")]
    public new Renderer renderer = null;

    public int materialIndex = 0;

    public string shaderFresnelParameterName = "_Fresnel";

    private Tween tween = null;

    private float currentFresnel = 0.0f;

    private void Start()
    {
        Usable usable = GetComponent<Usable>();

        usable.onHoverEnter.AddListener(HoverEnter);
        usable.onHoverLeave.AddListener(HoverLeave);

        if (renderer == null)
            renderer = GetComponentInChildren<Renderer>();

        if (renderer != null)
        {
            /*if (renderer.materials.Length <= materialIndex)
                return;*/

            /*Material mat = renderer.materials[materialIndex];

            if (mat == null)
                return;

            mat.SetFloat(shaderFresnelParameterName, 0.0f);*/
            //currentFresnel = 0.0f;

            SetFresnel(0.0f);
        }
    }

    private void HoverEnter(Usable.OnUsableEventArgs args)
    {
        if (renderer == null)
            return;

        if (tween != null && DOTween.IsTweening(tween))
            DOTween.Kill(tween);

        tween = DOTween.To((value) => { SetFresnel(value); }, currentFresnel, 1.0f, 0.5f).SetEase(Ease.OutCubic);
    }

    private void HoverLeave(Usable.OnUsableEventArgs args)
    {
        if (renderer == null)
            return;

        if (tween != null && DOTween.IsTweening(tween))
            DOTween.Kill(tween);

        tween = DOTween.To((value) => { SetFresnel(value); }, currentFresnel, 0.0f, 0.5f).SetEase(Ease.OutCubic);
    }

    public void SetFresnel(float value)
    {
        if (renderer == null)
            return;

        foreach (Material mat in renderer.materials)
            mat.SetFloat(shaderFresnelParameterName, value);

        /*if (renderer.materials.Length <= materialIndex)
            return;

        Material mat = renderer.materials[materialIndex];

        if (mat == null)
            return;

        mat.SetFloat(shaderFresnelParameterName, value);*/
        currentFresnel = value;
    }
}
