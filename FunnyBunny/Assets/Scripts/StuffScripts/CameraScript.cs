using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public MainController mainController;
    public Transform target;
    public float speed = 1f;

    void Update()
    {
        if (target == null || !mainController.is_dead) return;

        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(target.position.x, target.position.y, transform.position.z),
            Time.deltaTime * speed
        );
    }
}
