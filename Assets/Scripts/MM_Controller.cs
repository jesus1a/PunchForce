using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CS583
{
    public class MM_Controller : MonoBehaviour
    {
        
        public Button button_Play;
        public Button button_Charcter;
        public Button button_Settings;
        public Button button_About;
        public Button button_Quit;
        // Start is called before the first frame update
        void Start()
        {
            
            button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
            //button_Charcter = GameObject.Find("Button_Character").GetComponent<Button>();
            button_Settings = GameObject.Find("Button_Settings").GetComponent<Button>();
            button_About = GameObject.Find("Button_About").GetComponent<Button>();
            button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
            button_Play.onClick.AddListener(Load_CC);
            //.onClick.AddListener(Load_CC);
            button_Settings.onClick.AddListener(Load_Settings);
            button_About.onClick.AddListener(Load_About);
            button_Quit.onClick.AddListener(QuitApp);
            //button_Play.interactable = Script_GlobalVars.Instance.play;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void Awake()
        {
            //Play_ON();
        }

        public void QuitApp()
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void Load_CC()
        {
            Debug.Log("Load CharacterSelect");
            SceneManager.LoadScene("Scene_CharacterSelect");
        }

        public void Load_START()
        {
            Debug.Log("Load Scene_Play");
            SceneManager.LoadScene("Scene_Play");
        }

        public void Load_About()
        {
            Debug.Log("Load Scene_About");
            SceneManager.LoadScene("Scene_About");
        }

        public void Load_Settings()
        {
            Debug.Log("Load Scene_Play");
            SceneManager.LoadScene("Scene_Settings");
        }

        public void Play_ON()
        {
            if (Script_GlobalVars.Instance.play)
            {
                button_Play.transform.Find("Text").GetComponent<Text>().color = Color.white;
                button_Play.onClick.AddListener(Load_START);
            }
        }
    }
}
