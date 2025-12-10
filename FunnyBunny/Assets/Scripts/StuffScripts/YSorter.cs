using UnityEngine;
using UnityEngine.Rendering;

//[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(SpriteRenderer))]
public class YSorter : MonoBehaviour
{
    public int baseOrder = 0;
    public int mul = 10;

    //Renderer r;
    SpriteRenderer r;
    SortingGroup sg;

    //void Awake() => r = GetComponent<Renderer>();
    void Awake()
    {
        r = GetComponent<SpriteRenderer>();
        sg = GetComponent<SortingGroup>();
    }

    void LateUpdate()
    {
        if (sg != null)
        {
            int order = baseOrder - Mathf.RoundToInt(transform.position.y * mul);
            sg.sortingOrder = order;
        }
        else
        {
            r.sortingOrder = baseOrder - Mathf.RoundToInt(transform.position.y * mul);
        }
    }
}
