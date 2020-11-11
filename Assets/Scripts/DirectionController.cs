using System;
using UnityEngine;
using UnityEngine.UI;

public class DirectionController : MonoBehaviour
{
    public Action RaceEnded;
    public Action LapEnded;
    [SerializeField] private int laps;
    [SerializeField] private Text currentLapLabel;
    [Tooltip("Must stay in order")]
    [SerializeField] private CheckPoint[] checkPoints;
    private int currentCheckPoint;
    private int currentLap;

    private void Start()
    {
        checkPoints[currentCheckPoint].Check += NewPoint;
        currentLapLabel.text = currentLap + "/" + laps;
    }

    //tracking system, only if player move in correct way add progress
    private void NewPoint()
    {
        checkPoints[currentCheckPoint].Check -= NewPoint;

        if (currentCheckPoint == checkPoints.Length - 1)
        {
            LapEnded?.Invoke();
            currentCheckPoint = 0;
            currentLap++;
            currentLapLabel.text = currentLap + "/" + laps;

            if (currentLap == laps)
            {
                RaceEnded?.Invoke();
                return;
            }
        }
        else
        {
            currentCheckPoint++;
        }

        checkPoints[currentCheckPoint].Check += NewPoint;
    }
}