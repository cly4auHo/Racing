using UnityEngine;

public class BonusCreator : MonoBehaviour
{
    [Header("Borders op spawn bonuses")]
    [SerializeField] private float zTop;
    [SerializeField] private float zBot;
    [SerializeField] private float xLeft;
    [SerializeField] private float xRight;
    [SerializeField] private float zTopInside;
    [SerializeField] private float zBotInside;
    [SerializeField] private float xLeftInside;
    [SerializeField] private float xRightInside;
    [Header("Settings")]
    [SerializeField] private float delayBetweenSpawnBonus = 5;
    //[SerializeField] private float minTim
    [SerializeField] private Bonus[] bonusePrefabs;

    private void Start()
    {

    }

    private void Update()
    {

    }
}
