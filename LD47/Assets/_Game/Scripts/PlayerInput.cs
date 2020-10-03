using Rewired;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerInput : SerializedMonoBehaviour
{
    [Required]
    public new Camera camera = null;

    [Required]
    public CinemachineVirtualCamera vcam = null;

    [OnValueChanged("UpdatePlayerIndex")]
    public int playerIndex = 0;

    [FoldoutGroup("InputNames")]
    public string horizontalInputName = "Horizontal";
    [FoldoutGroup("InputNames")]
    public string verticalInputName = "Vertical";
    [FoldoutGroup("InputNames")]
    public string walkInputName = "Walk";
    [FoldoutGroup("InputNames")]
    public string useInputName = "Use";
    [FoldoutGroup("InputNames")]
    public string throwInputName = "Throw";

    [Space]

    [FoldoutGroup("InputNames")]
    public string mouseHorizontalInputName = "LookHorizontal";
    [FoldoutGroup("InputNames")]
    public string mouseVerticalInputName = "LookVertical";

    [Space]

    public UnityEvent onUseUp = new UnityEvent();
    public UnityEvent onUseDown = new UnityEvent();

    public UnityEvent onThrowUp = new UnityEvent();
    public UnityEvent onThrowDown = new UnityEvent();

    public float joystickLookInputMultiplier = 3.0f;

    private Player rewiredPlayer = null;

    private float currentLookMultiplier = 1.0f;

    private void Start()
    {
        UpdatePlayerIndex();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UpdatePlayerIndex()
    {
        rewiredPlayer = ReInput.players.GetPlayer(playerIndex);
        rewiredPlayer.controllers.AddLastActiveControllerChangedDelegate((player, controller) => 
        {
            if (controller.type == ControllerType.Joystick)
                currentLookMultiplier = joystickLookInputMultiplier;
            else
                currentLookMultiplier = 1.0f;
        });
    }

    private void Update()
    {
        if (rewiredPlayer.GetButtonDown(useInputName))
            onUseDown?.Invoke();
        else if (rewiredPlayer.GetButtonUp(useInputName))
            onUseUp?.Invoke();

        if (rewiredPlayer.GetButtonDown(throwInputName))
            onThrowDown?.Invoke();
        else if (rewiredPlayer.GetButtonUp(throwInputName))
            onThrowUp?.Invoke();
    }

    public float GetHorizontal() => rewiredPlayer.GetAxis(horizontalInputName);
    public float GetVertical() => rewiredPlayer.GetAxis(verticalInputName);

    public float GetMouseHorizontal() => rewiredPlayer.GetAxis(mouseHorizontalInputName) * currentLookMultiplier;
    public float GetMouseVertical() => rewiredPlayer.GetAxis(mouseVerticalInputName) * currentLookMultiplier;

    public bool GetWalk() => rewiredPlayer.GetButton(walkInputName);
}
