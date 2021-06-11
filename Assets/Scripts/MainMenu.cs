using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
	[SerializeField] private InputField playerNameInputField;
	[SerializeField] private Text titleText;

    private PlayerData PlayerData => GameDataManager.Instance.playerData;


    private void Start()
	{
		playerNameInputField.text = PlayerData.playerName;
		SetTitleText();
	}

	private void SetTitleText()
	{
		titleText.text = $"HighScore : {PlayerData.playerName} : {PlayerData.highScore}";
	}

	public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameDataManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif    
    }

    public void SetPlayerName(string name)
	{
        PlayerData.playerName = name;
		SetTitleText();
	}
}