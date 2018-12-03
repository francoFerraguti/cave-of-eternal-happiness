using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject kneeling;

    bool introMovingForward = false;
    float introWalkSpeed = 8.0f;

    float introSineSpeed = 4.0f;
    float introSineFrequency = 4.0f;  // Speed of sine movement
    float introSineMagnitude = 0.07f;   // Size of sine movement

    bool introKneeling = false;
    float introKneelSpeed = 24.0f;
    float introKneelRotateSpeed = 20.0f;
    bool introKneelChangedDirection = false;

    bool introGettingUp = false;
    float introGetUpSpeed = 24.0f;

    bool introGoingBack = false;
    float introGoingBackSpeed = 24.0f;
    float introGoingBackRotationSpeed = 1.3f;


    void Update()
    {
        introMoveForward();
        introKneel();
        introGetUp();
        introGoBack();
    }

    void introGoBack()
    {
        if (!introGoingBack)
        {
            return;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * introGoingBackSpeed, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(10, 180, 0), Time.deltaTime * introGoingBackRotationSpeed);

        if (transform.position.z >= 120.0f)
        {
            introGoingBack = false;
            GameObject.Find("Main Camera").GetComponent<SoundManagerScript>().playWhat();
            GameObject.Find("Main Camera").GetComponent<CameraShakeScript>().SetShaking(0.8f);
        }
    }

    void introGetUp()
    {
        if (!introGettingUp)
        {
            return;
        }

        transform.Translate(Vector3.up * Time.deltaTime * introGetUpSpeed, Space.World);

        if (transform.position.y >= 62.0f)
        {
            kneeling.SetActive(true);
            introGettingUp = false;
            introGoingBack = true;
        }
    }

    void introKneel()
    {
        if (!introKneeling)
        {
            return;
        }

        transform.Translate(-Vector3.up * Time.deltaTime * introKneelSpeed, Space.World);

        if (!introKneelChangedDirection)
        {
            transform.RotateAround(transform.position, transform.right, Time.deltaTime * introKneelRotateSpeed);
        }
        else
        {
            transform.RotateAround(transform.position, transform.right, -Time.deltaTime * introKneelRotateSpeed * 1.3f);
        }

        if (transform.position.y <= 56)
        {
            introKneelChangedDirection = true;
        }

        if (transform.position.y <= 28)
        {
            introKneeling = false;
        }
    }

    void introMoveForward()
    {
        if (!introMovingForward)
        {
            return;
        }

        transform.Translate(-Vector3.forward * Time.deltaTime * introWalkSpeed, Space.World);

        Vector3 pos = transform.position;
        pos += transform.up * Time.deltaTime * introSineSpeed / 6;
        transform.position = pos - Vector3.up * Mathf.Sin(Time.time * introSineFrequency) * introSineMagnitude / 2;

        if (transform.position.z <= 85)
        {
            introMovingForward = false;
        }
    }

    public void SetIntroMoveForward()
    {
        introMovingForward = true;
    }

    public void SetIntroKneeling()
    {
        introKneeling = true;
        GameObject.Find("altar").GetComponent<AltarScript>().SetBlackening();
    }

    public void SetIntroGettingUp()
    {
        introGettingUp = true;
    }
}
