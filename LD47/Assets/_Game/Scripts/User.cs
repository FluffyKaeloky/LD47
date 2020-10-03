using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class UserControl : SerializedMonoBehaviour
{
    public abstract void UseUp();
    public abstract void UseDown();

    public abstract void UseAltUp();
    public abstract void UseAltDown();
}
