using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Func<int> Taking;
    [SerializeField] private int score;
    private const string playerTag = "Player";

    private void Start()
    {
        Taking = Take;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Taking?.Invoke();
        }
    }

    private int Take()
    {
        return score;
    }
}
