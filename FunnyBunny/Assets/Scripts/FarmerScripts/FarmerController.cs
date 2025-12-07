using UnityEngine;

public class FarmerController : MonoBehaviour
{
    public GameObject gun_GO;

    GunScript gunScript;

    [SerializeField] float max_anger_level;

    float current_anger_level;

    void Start()
    {
        gunScript = gun_GO.GetComponent<GunScript>();

        //StartShooting();
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
