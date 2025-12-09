using UnityEngine;

public abstract class NPCController : MonoBehaviour
{
    protected UIController UIcontroller;

    protected virtual void Start()
    {
        UIcontroller = GameObject.Find("Canvas").GetComponent<UIController>();
    }
}
