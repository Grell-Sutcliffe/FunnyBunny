using UnityEngine;

public interface Activities 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Trigger();
    Point GetPoint();
    bool IsActive();
    void MakeActive();

    void Click(int id);
    int GetKey();
   
}
