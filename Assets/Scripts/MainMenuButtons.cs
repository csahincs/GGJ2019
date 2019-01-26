using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button startBtn;
    public Button optionsBtn;
    public Button exitBtn;


    public void Start()
    {
        startBtn.onClick.RemoveAllListeners();
        startBtn.onClick.AddListener(StartBtnClicked);
        exitBtn.onClick.RemoveAllListeners();
        exitBtn.onClick.AddListener(ExitBtnClicked);
    }

    private void StartBtnClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OptionsBtnClicked()
    {

    }

    private void ExitBtnClicked()
    {
        Application.Quit();
    }
}
