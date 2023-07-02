using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private Player player;

    private void Awake()
    {
        player.onHexExit += UpdateScore;
        restartButton.onClick.AddListener(Restart);
        homeButton.onClick.AddListener(BackToHome);
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
