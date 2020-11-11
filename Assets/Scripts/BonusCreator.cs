using System.Collections;
using UnityEngine;

public class BonusCreator : MonoBehaviour
{
    [Header("Borders op spawn bonuses")]
    [SerializeField] private float[] zBorders;
    [SerializeField] private float[] xBorders;
    [SerializeField] private float[] zInsideBorders;
    [SerializeField] private float[] xInsideBorders;
    [SerializeField] private float height = 1;
    [Header("Settings")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float delayBetweenSpawnBonus = 5;
    [SerializeField] private Bonus[] bonusePrefabs;

    public void StartGame()
    {
        StartCoroutine(CreateBonus());
    }

    private IEnumerator CreateBonus()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBetweenSpawnBonus);
            Bonus bonus = Instantiate(bonusePrefabs[Random.Range(0, bonusePrefabs.Length)], RandomPosition(), Quaternion.identity, transform);
            bonus.Init(scoreManager);
        }
    }

    private Vector3 RandomPosition()
    {
        int randomZSide = Random.Range(0, 2);
        int randomXSide = Random.Range(0, 2);

        float randomX = Random.Range(xInsideBorders[randomXSide], xBorders[randomXSide]);
        float randomZ = Random.Range(zInsideBorders[randomZSide], zBorders[randomZSide]);

        return new Vector3(randomX, height, randomZ);
    }
}
