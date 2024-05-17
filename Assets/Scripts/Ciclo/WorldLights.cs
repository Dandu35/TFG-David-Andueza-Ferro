using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;


[RequireComponent(typeof(Light2D))]
public class WorldLights : MonoBehaviour
{
    
    private Light2D light;
    [SerializeField]
    private WorldTime tiempoMundo;
    [SerializeField]
    private Gradient gradient;


    private void Awake()
    {
        light = GetComponent<Light2D>();
        tiempoMundo.WorldTimeChanged += OnWorldTimeChanged;
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }

    private void OnDestroy()
    {
        tiempoMundo.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        light.color = gradient.Evaluate(PercentOfDay(newTime));
    }
}




