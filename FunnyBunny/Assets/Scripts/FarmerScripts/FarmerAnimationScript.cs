using UnityEngine;

public class FarmerAnimationScript : MonoBehaviour
{
    FarmerMovementScript farmerMovementScript;

    private void Start()
    {
        farmerMovementScript = GetComponentInParent<FarmerMovementScript>();
    }

    public void StopAngerAnimation()
    {
        farmerMovementScript.StopAngerAnimation();
    }

    public void StartHeartAttackAnimation()
    {
        farmerMovementScript.SetAllAngerParametersFalse();
    }
}
