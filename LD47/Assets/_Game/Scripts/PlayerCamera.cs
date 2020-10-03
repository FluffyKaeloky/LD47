using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RewiredPlayer))]
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

    private RewiredPlayer player = null;

    private float horizontal, vertical;

    private float angle = 0.0f;

    private void Awake()
    {
        player = GetComponent<RewiredPlayer>();
    }

    private void Update()
    {
        horizontal = player.Player.GetAxis(horizontalCameraInputName);
        vertical = player.Player.GetAxis(verticalCameraInputName);
    }

    private void FixedUpdate()
    {
        horizontalPivot.Rotate(Vector3.up, horizontal * sensitivity);

        angle = Mathf.Clamp(angle - vertical * sensitivity, minVerticalAngle, maxVerticalAngle);

        verticalPivot.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
    }
}
