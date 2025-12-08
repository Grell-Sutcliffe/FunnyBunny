using Unity.VisualScripting;
using UnityEngine;

public class HealthBarScript : BarController
{
    protected override void Start()
    {
        base.Start();

        SetBarFull();
    }
}
