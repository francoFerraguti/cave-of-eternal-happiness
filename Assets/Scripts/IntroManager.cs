using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    GameObject camera;
    GameObject textManager;

    float timer = 0;

    float time1 = 2.5f;
    float time2 = 6.5f;

    float timeIntroMoveForward = 7.0f;

    float time3 = 12.5f;

    float timeIntroKneel = 18.5f;

    float time4 = 20.5f;

    float timeSoundDisableFire = 24.0f;
    float timeDisableFire = 24.5f;

    float timeMoveAltar = 25.5f;

    float timeGuardianExit = 28.0f;

    float timeGetUp = 30.0f;

    float time5 = 33.0f;
    float time6 = 34.5f;

    void Awake()
    {
        textManager = GameObject.Find("TextManager");
        camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= time1)
        {
            time1 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("Come forth, traveller", 1);
            camera.GetComponent<SoundManagerScript>().playComeForth();
        }

        if (timer >= time2)
        {
            time2 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("You've reached the cave of eternal happiness", 2);
            camera.GetComponent<SoundManagerScript>().playCave();
        }

        if (timer >= timeIntroMoveForward)
        {
            timeIntroMoveForward = float.MaxValue;
            camera.GetComponent<CameraScript>().SetIntroMoveForward();
        }

        if (timer >= time3)
        {
            time3 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("Kneel before me if you wish to partake in this trial", 1);
            camera.GetComponent<SoundManagerScript>().playKneel();
        }

        if (timer >= timeIntroKneel)
        {
            timeIntroKneel = float.MaxValue;
            camera.GetComponent<CameraScript>().SetIntroKneeling();
        }

        if (timer >= time4)
        {
            time4 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("But beware... You just might lose yourself along the way", 1);
            camera.GetComponent<SoundManagerScript>().playBeware();
        }

        if (timer >= timeSoundDisableFire)
        {
            timeSoundDisableFire = float.MaxValue;
            GameObject.Find("Guardian").GetComponent<AudioSource>().Play();
        }

        if (timer >= timeDisableFire)
        {
            timeDisableFire = float.MaxValue;
            GameObject.Find("Fire").GetComponent<AudioSource>().Stop();
            GameObject.Find("Fire").SetActive(false);
        }

        if (timer >= timeMoveAltar)
        {
            timeMoveAltar = float.MaxValue;
            GameObject.Find("altar").GetComponent<AltarScript>().SetMoving();
        }

        if (timer >= timeGuardianExit)
        {
            timeGuardianExit = float.MaxValue;
            GameObject.Find("guardian").GetComponent<GuardianScript>().SetExit();
        }

        if (timer >= timeGetUp)
        {
            timeGetUp = float.MaxValue;
            camera.GetComponent<CameraScript>().SetIntroGettingUp();
        }

        if (timer >= time5)
        {
            time5 = float.MaxValue;
            textManager.GetComponent<TextManager>().SetText("W-WHAAAAAAAAAAAAAAAAT?!?!???!?!??!!!?", 3, 0.7f);
        }

        if (timer >= time6)
        {
            time6 = float.MaxValue;
            camera.GetComponent<MovementScript>().SetIntroFinished();
            camera.GetComponent<MouseScript>().SetIntroFinished();
            textManager.GetComponent<TextManager>().SetText("If my body is there... Am I... A... Ghost? Neat~", 4, 2.4f);
            camera.GetComponent<SoundManagerScript>().playNeat();
        }
    }
}
