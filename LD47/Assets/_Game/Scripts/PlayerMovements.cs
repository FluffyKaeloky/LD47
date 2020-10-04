using Rewired;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float walkMultiplier = 0.5f;

    public float moveSpeedMultiplier = 1.0f;

    [FoldoutGroup("InputNames")]
    public string horizontalMovementInputName = "Horizontal";
    [FoldoutGroup("InputNames")]
    public string verticalMovementInputName = "Vertical";
    [FoldoutGroup("InputNames")]
    public string walkInputName = "Walk";

    private CharacterController controller = null;

    private PlayerInput playerInput = null;

    public float Vertical { get; private set; } = 0.0f;
    public float Horizontal { get; private set; } = 0.0f;

    public bool IsWalking { get; private set; } = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Vertical = playerInput.GetVertical();
        Horizontal = playerInput.GetHorizontal();
        IsWalking = playerInput.GetWalk();
    }

    private void FixedUpdate()
    {
        Vector3 inputs = new Vector3(Horizontal, 0.0f, Vertical);

        inputs = transform.rotation * inputs;

        Vector3 delta = new Vector3(moveSpeed * moveSpeedMultiplier * inputs.x, 0.0f, moveSpeed * inputs.z) + (Physics.gravity * Time.fixedDeltaTime);
        delta.Scale(IsWalking ? Vector3.one * walkMultiplier : Vector3.one);

        controller.Move(delta);

        moveSpeedMultiplier = Mathf.Clamp(moveSpeedMultiplier + Time.fixedDeltaTime * 2.0f, 0.0f, 1.0f);
    }
}
