using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameMenu : MonoBehaviour
{
    public Canvas canvas;
    public Button restartButton;
    public Text TextToPlayer;
    public string CurentSceneName;
    public LoadingLogicPage LoadingLogic;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Awake()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    public void TheEndOfGame(string text)
    {
        canvas.gameObject.SetActive(true);
        TextToPlayer.text = text;
        Time.timeScale = 0;

    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        LoadingLogic.LoadScene(CurentSceneName);
    }
}
