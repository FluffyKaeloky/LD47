using Rewired;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(RewiredPlayer))]
public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float walkMultiplier = 0.5f;

    [FoldoutGroup("InputNames")]
    public string horizontalMovementInputName = "Horizontal";
    [FoldoutGroup("InputNames")]
    public string verticalMovementInputName = "Vertical";
    [FoldoutGroup("InputNames")]
    public string walkInputName = "Walk";

    private CharacterController controller = null;

    private RewiredPlayer player = null;

    private float vertical, horizontal;
    private bool walk;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        player = GetComponent<RewiredPlayer>();
    }

    private void Update()
    {
        vertical = player.Player.GetAxis(verticalMovementInputName);
        horizontal = player.Player.GetAxis(horizontalMovementInputName);
        walk = player.Player.GetButton(walkInputName);
    }

    private void FixedUpdate()
    {
        /*Vector3 inputs = new Vector3(horizontal, 0.0f, vertical);
        Debug.Log("Inputs : " + inputs);

        if (forward != null)
        {
            float angle = forward.rotation.eulerAngles.y;
            Debug.Log("Angle : " + angle);
            inputs = Quaternion.AngleAxis(angle, Vector3.up) * inputs;
            Debug.Log("Transformed Inputs : " + inputs);
        }*/

        Vector3 inputs = new Vector3(horizontal, 0.0f, vertical);

        inputs = transform.rotation * inputs;

        Vector3 delta = new Vector3(moveSpeed * inputs.x, 0.0f, moveSpeed * inputs.z) + (Physics.gravity * Time.fixedDeltaTime);
        delta.Scale(walk ? Vector3.one * walkMultiplier : Vector3.one);

        controller.Move(delta);
    }
}
