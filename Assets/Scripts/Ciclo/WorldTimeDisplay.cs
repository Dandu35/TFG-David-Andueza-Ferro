using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private WorldTime tiempoMundo;
    public static int CurrentDay { get; private set; } = 1;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        tiempoMundo.WorldTimeChanged += OnWorldTimeChanged;
    }

    private void OnDestroy()
    {
        tiempoMundo.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        // Calcular el d�a actual
        int day = (int)Math.Floor(newTime.TotalMinutes / WorldTimeConstants.MinutesInDay) + 1;

        // Si el d�a actual es diferente al d�a almacenado en la propiedad est�tica, actualizar la propiedad y actualizar el texto
        if (day != CurrentDay)
        {
            CurrentDay = day;
            UpdateText(newTime);
        }
        else
        {
            // Si el d�a es el mismo, solo actualizar la hora y los minutos en el texto
            UpdateTime(newTime);
        }
    }

    private void UpdateText(TimeSpan newTime)
    {
        // Obtener la hora y los minutos
        string time = newTime.ToString(@"hh\:mm");

        // Mostrar el d�a y la hora/minuto en el texto
        text.SetText("Day " + CurrentDay + ", " + time);
    }

    private void UpdateTime(TimeSpan newTime)
    {
        // Obtener solo la hora y los minutos
        string time = newTime.ToString(@"hh\:mm");

        // Mostrar solo la hora y los minutos en el texto sin cambiar el d�a
        text.SetText("Day " + CurrentDay + ", " + time);
    }
}
