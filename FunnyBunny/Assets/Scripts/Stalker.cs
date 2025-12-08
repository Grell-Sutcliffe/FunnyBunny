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

    public void ChangeImg(Sprite i)
    {
        Debug.Log(1111);
        img.sprite = i;
    }
}
