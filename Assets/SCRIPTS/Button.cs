using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IPressable
{

    public UnityEvent OnPress;



    //preseable

    public void Press()
    {
        OnPress.Invoke();
    }
}
