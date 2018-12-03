using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour
{
    Vector3 currentRot;

    public float velRot = 160.0f;
    float minRotX = -30.0f;
    float maxRotX = 90.0f;

    bool introFinished = false;

    public void SetIntroFinished()
    {
        Cursor.visible = false;

        BoxCollider[] colliders = GameObject.Find("entrance_01").GetComponents<BoxCollider>();
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = true;
        }

        currentRot = transform.eulerAngles;
        introFinished = true;
    }

    void Update()
    {
        if (!introFinished)
        {
            return;
        }

        currentRot.y += Input.GetAxis("Mouse X") * velRot * Time.deltaTime;
        transform.localEulerAngles = currentRot; //horizontal

        currentRot.x -= Input.GetAxis("Mouse Y") * velRot * Time.deltaTime;
        currentRot.x = Mathf.Clamp(currentRot.x, minRotX, maxRotX);
        transform.localEulerAngles = currentRot;
    }
}