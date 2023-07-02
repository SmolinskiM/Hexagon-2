using UnityEngine;

public class GameManager : SingletoneMonobehaviour<GameManager>
{
    [SerializeField] private GameObject endGameScreen;

    public int Score { get; set; }

    public void EndGame()
    {
        Time.timeScale = 0;
        endGameScreen.SetActive(true);
    }

}
