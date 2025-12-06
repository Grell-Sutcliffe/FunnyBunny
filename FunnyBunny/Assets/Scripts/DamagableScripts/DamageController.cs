using UnityEngine;

public abstract class DamageController : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(gameObject);
    }
}
