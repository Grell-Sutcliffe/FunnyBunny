using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Stalker : MonoBehaviour
{
    [SerializeField]
    Image img;
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ChangeImg(Image i)
    {
        img = i;
    }
}
