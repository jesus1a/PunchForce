using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_SplashScreen : MonoBehaviour
{
    public Button button_Play;
    public Button button_Quit;
    // Start is called before the first frame update
    void Start()
    {
        button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
        button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
        button_Play.onClick.AddListener(loadMM);
        button_Quit.onClick.AddListener(QuitApp);
    }

    public void loadMM()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }

    public void QuitApp()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
