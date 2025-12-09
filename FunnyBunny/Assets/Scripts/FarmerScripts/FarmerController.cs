using UnityEngine;

public class FarmerController : MonoBehaviour
{
    UIController UIcontroller;

    public GameObject gun_GO;

    GunScript gunScript;

    [SerializeField] float max_anger_level;

    float current_anger_level;

    void Start()
    {
        UIcontroller = GameObject.Find("Canvas").GetComponent<UIController>();

        gunScript = gun_GO.GetComponent<GunScript>();

        current_anger_level = 0f;

       //StartShooting();
    }

    public void ChangeAnger(float amount)
    {
        current_anger_level += amount;

        UIcontroller.SetAngerBarPercent(current_anger_level / max_anger_level);
    }

    void StartShooting()
    {
        gunScript.StartShooting();
    }

    void StopShooting()
    {
        gunScript.StopShooting();
    }
}
