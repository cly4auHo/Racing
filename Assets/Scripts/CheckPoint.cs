using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Action Check;
    private const string playerTag = "Player";

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Check?.Invoke();
        }
    }
}
