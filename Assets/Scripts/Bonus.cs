using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int score;
    private ScoreManager scoreManager;
    private const string playerTag = "Player";

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            scoreManager.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}
