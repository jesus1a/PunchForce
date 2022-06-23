using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button_Quit;
    void Start()
    {
        button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
        button_Quit.onClick.AddListener(loadMM);
    }

    public void loadMM()
    {
        SceneManager.LoadScene("Scene_MainMenu");
    }
}
