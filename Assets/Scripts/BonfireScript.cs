using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{

    ParticleSystem particleSystem;
    Renderer altarRenderer;

    float timer = 0;
    float timeToStart = 1.2f;
    float timeToMiddle = 1.6f;
    float timeToMaximize = 2.6f;

    float middleSpeed = 2.0f;
    float maximizedSpeed = 3.0f;

    void Awake()
    {
        particleSystem = this.GetComponent<ParticleSystem>();
        altarRenderer = GameObject.Find("altar").GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!particleSystem.isPlaying && timer >= timeToStart)
        {
            particleSystem.Play();
        }

        if (particleSystem.startSpeed < middleSpeed && timer > timeToMiddle)
        {
            particleSystem.startSpeed = middleSpeed;
        }

        if (particleSystem.startSpeed < maximizedSpeed && timer > timeToMaximize)
        {
            particleSystem.startSpeed = maximizedSpeed;

        }

        if (particleSystem.isPlaying && particleSystem.lights.intensityMultiplier <= 1.8f)
        {
            var lights = particleSystem.lights;
            lights.intensityMultiplier += 0.002f;

            var currentColor = altarRenderer.material.GetColor("_ReflectColor");
            if (currentColor.g < 0.4f)
            {
                altarRenderer.material.SetColor("_ReflectColor", currentColor + new Color(0.01f, 0.01f, 0, 0));
            }
            else if (currentColor.r < 1.0f)
            {
                altarRenderer.material.SetColor("_ReflectColor", currentColor + new Color(0.01f, 0, 0, 0));
            }
        }
    }
}
