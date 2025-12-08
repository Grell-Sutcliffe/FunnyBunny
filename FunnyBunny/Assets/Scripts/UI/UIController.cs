using UnityEngine;

public class UIController : MonoBehaviour
{
    HealthBarScript healthBarScript;
    AngerBarScript angerBarScript;

    public GameObject healthBar;
    public GameObject angerBar;

    void Start()
    {
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        angerBarScript = angerBar.GetComponent<AngerBarScript>();
    }

    public void SetHealthBarPercent(float percent)
    {
        healthBarScript.SetBarPercent(percent);
    }

    public void SetAngerBarPercent(float percent)
    {
        angerBarScript.SetBarPercent(percent);
    }
}
