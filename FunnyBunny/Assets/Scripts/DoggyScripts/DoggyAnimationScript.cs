using UnityEngine;

public class DoggyAnimationScript : MonoBehaviour
{
    DoggyMovementScript doggyMovementScript;

    private void Start()
    {
        doggyMovementScript = GetComponentInParent<DoggyMovementScript>();
    }

    public void StopAngerAnimation()
    {
        doggyMovementScript.StopAngerAnimation();
    }
}
