using UnityEngine;

public class FarmerController : MonoBehaviour
{
    UIController UIcontroller;

    public GameObject gun_GO;

    GunScript gunScript;

    [SerializeField] float max_anger_level;

    float current_anger_level;

    public float current_anger_percent = 0f;

    void Start()
    {
        UIcontroller = GameObject.Find("Canvas").GetComponent<UIController>();

        gunScript = gun_GO.GetComponent<GunScript>();

        current_anger_level = 0f;

        StopShooting();
    }

    public void ChangeAnger(float amount)
    {
        current_anger_level += amount;

        if (current_anger_level > max_anger_level)
        {
            current_anger_level = max_anger_level;
        }
        if (current_anger_level < 0f)
        {
            current_anger_level = 0f;
        }

        current_anger_percent = current_anger_level / max_anger_level;

        UIcontroller.SetAngerBarPercent(current_anger_percent);
    }

    public void ChangeAngerPercent(float amount)
    {
        Debug.Log($"DEDUS kryt {amount}");
        current_anger_percent += amount;

        if (current_anger_percent > 1f)
        {
            current_anger_percent = 1f;
        }
        if (current_anger_level < 0f)
        {
            current_anger_percent = 0f;
        }

        current_anger_level = max_anger_level / current_anger_percent;

        UIcontroller.SetAngerBarPercent(current_anger_percent);
    }

    public void StartShooting()
    {
        gun_GO.SetActive(true);
        gunScript.StartShooting();
    }

    public void StopShooting()
    {
        gun_GO.SetActive(false);
        gunScript.StopShooting();
    }
}
