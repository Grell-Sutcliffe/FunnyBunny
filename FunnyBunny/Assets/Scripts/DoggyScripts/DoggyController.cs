using UnityEngine;

public class DoggyController : MonoBehaviour
{
    public GameObject dream_about_sausage_GO;
    public GameObject noticableArea_GO;

    DoggyMovementScript doggyMovementScript;

    // public bool is_hungry = true;  // is_happy = false;

    void Start()
    {
        doggyMovementScript = GetComponent<DoggyMovementScript>();
    }

    public void FeedDog()
    {
        noticableArea_GO.SetActive(false);
        doggyMovementScript.FeedDog();
    }
}
