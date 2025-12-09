using UnityEngine;

//[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(SpriteRenderer))]
public class YSorter : MonoBehaviour
{
    public int baseOrder = 0;
    public int mul = 10;

    //Renderer r;
    SpriteRenderer r;

    //void Awake() => r = GetComponent<Renderer>();
    void Awake() => r = GetComponent<SpriteRenderer>();

    void LateUpdate()
    {
        r.sortingOrder = baseOrder - Mathf.RoundToInt(transform.position.y * mul);
    }
}
