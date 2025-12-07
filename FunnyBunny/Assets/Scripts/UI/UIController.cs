using UnityEngine;

public class UIController : MonoBehaviour
{
    HealthBarScript healthBarScript;

    public GameObject healthBar;

    void Start()
    {
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
    }

    public void SetHealthBarPercent(float percent)
    {
        healthBarScript.SetHealthBarPercent(percent);
    }
}
