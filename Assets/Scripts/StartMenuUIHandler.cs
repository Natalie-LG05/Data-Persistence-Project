using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TMP_InputField nameInputField;

    private void Start()
    {
        UpdateHighscoreText();

        // if there is a previously saved name, fill in the input field with it
        string playerName = HighscoreHandler.Instance.playerName;
        if (playerName.Length > 0) {
            nameInputField.text = playerName;
        }
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
