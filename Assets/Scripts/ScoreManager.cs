using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private RecordSaver saver;
    [SerializeField] private DirectionController directionController;
    [SerializeField] private Text scoreLabel;
    [SerializeField] private float minTimeToGetScore;
    private float timer;
    private int score;

    private void Start()
    {
        directionController.LapEnded += LapEnded;
        directionController.RaceEnded += GameEnded;
    }

    public void GameStarted()
    {
        timer = minTimeToGetScore + Time.timeSinceLevelLoad;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreLabel.text = this.score.ToString();
    }

    private void LapEnded()
    {
        score += Mathf.Max(0, Convert.ToInt32(timer - Time.timeSinceLevelLoad));
        timer += minTimeToGetScore; //add time for new lap
        scoreLabel.text = score.ToString();
    }

    private void GameEnded()
    {
        saver.AddRecord(score);
        directionController.LapEnded -= LapEnded;
        directionController.RaceEnded -= GameEnded;
    }
}
