using UnityEngine;
using UnityEngine.EventSystems;

public class OKeyLayer : Bebebe, Activities, IPointerDownHandler
{
    [SerializeField]
    float timer = 0.5f;
    protected override void Start()
    {
        base.Start();
        point = new Point(gameObject, timer);

    }
    public bool IsActive()
    {
        return false;
    }

    public int GetKey()
    {
        return 0;
    }
    public void MakeActive()
    {
    }
    public void Trigger()
    {
        if (!mainController.KeyTaked){ 
            GameObject ss = Instantiate(mainController.RetPref(2), transform.position, Quaternion.identity); // Jen
            mainController.KeyTaked = true;
        }
        else if (!mainController.WasAngry1) { 
            mainController.FC.ChangeAngerPercent(0.2f);
            mainController.WasAngry1 = true;
        }
    }

    public Point GetPoint()
    {
        return point;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("MP");

    }



}
