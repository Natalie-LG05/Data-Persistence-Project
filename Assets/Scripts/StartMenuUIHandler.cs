using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        UpdateHighscoreText();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(string playerName)
    {
        HighscoreHandler.Instance.playerName = playerName;
        UpdateHighscoreText();
    }

    private void UpdateHighscoreText()
    {
        highscoreText.text = $"Highscore : {HighscoreHandler.Instance.playerName} : {HighscoreHandler.Instance.highscore}";
    }
}
