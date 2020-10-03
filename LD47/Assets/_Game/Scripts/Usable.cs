using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

public class Usable : SerializedMonoBehaviour
{
    [Serializable]
    public class OnUsableEvent : UnityEvent<OnUsableEventArgs> { }

    [Serializable]
    public class OnUsableEventArgs
    {
        public UserControl Instigator { get; } = null;

        public OnUsableEventArgs(UserControl instigator)
        {
            Instigator = instigator;
        }
    }

    public OnUsableEvent onHoverEnter = new OnUsableEvent();
    public OnUsableEvent onHoverLeave = new OnUsableEvent();

    public OnUsableEvent onMouseUp = new OnUsableEvent();
    public OnUsableEvent onMouseDown = new OnUsableEvent();

    public OnUsableEvent onMouseAltUp = new OnUsableEvent();
    public OnUsableEvent onMouseAltDown = new OnUsableEvent();

    public void HoverEnter(UserControl instigator) => onHoverEnter?.Invoke(new OnUsableEventArgs(instigator));
    public void HoverLeave(UserControl instigator) => onHoverLeave?.Invoke(new OnUsableEventArgs(instigator));

    public void MouseUp(UserControl instigator) => onMouseUp?.Invoke(new OnUsableEventArgs(instigator));
    public void MouseDown(UserControl instigator) => onMouseDown?.Invoke(new OnUsableEventArgs(instigator));

    public void MouseAltUp(UserControl instigator) => onMouseAltUp?.Invoke(new OnUsableEventArgs(instigator));
    public void MouseAltDown(UserControl instigator) => onMouseAltDown?.Invoke(new OnUsableEventArgs(instigator));
}
