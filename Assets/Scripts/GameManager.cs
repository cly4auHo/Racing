using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pause;

    private void Start()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Play()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowScore()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}