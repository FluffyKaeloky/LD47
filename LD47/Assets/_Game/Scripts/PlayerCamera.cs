using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerCamera : MonoBehaviour
{
    public Transform horizontalPivot = null;
    public Transform verticalPivot = null;

    public float minVerticalAngle = 75.0f;
    public float maxVerticalAngle = -75.0f;

    public float sensitivity = 1.0f;

    [FoldoutGroup("InputNames")]
    public string horizontalCameraInputName = "LookHorizontal";
    [FoldoutGroup("InputNames")]
    public string verticalCameraInputName = "LookVertical";

    private PlayerInput playerInput = null;

    private float horizontal, vertical;

    private float angle = 0.0f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        horizontal = playerInput.GetMouseHorizontal();
        vertical = playerInput.GetMouseVertical();

        horizontalPivot.Rotate(Vector3.up, horizontal * sensitivity);

        angle = Mathf.Clamp(angle - vertical * sensitivity, minVerticalAngle, maxVerticalAngle);

        verticalPivot.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
    }

    public void ResetCamera()
    {
        angle = 0;
    }
}
