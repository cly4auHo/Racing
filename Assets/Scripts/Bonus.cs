using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int score;
    private const string playerTag = "Player";

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            
        }
    }
}
