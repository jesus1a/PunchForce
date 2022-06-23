using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CS583
{
    public class Settings_Conroller : MonoBehaviour
    {
        public Button button_Quit;
        public Toggle thumbs;
        public Slider slider;
        // Start is called before the first frame update
        void Start()
        {
            button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
            button_Quit.onClick.AddListener(Load_START);
            thumbs = GameObject.Find("Toggle_ThumbSticks").GetComponent<Toggle>();
            slider = GameObject.Find("Slider_Music").GetComponent<Slider>();
            slider.value = Script_GlobalVars.Instance.musicControl.volume;
            slider.onValueChanged.AddListener(delegate { musicChange(); });
        }

        // Update is called once per frame
        void Update()
        {
            Script_GlobalVars.Instance.useThumbSticks = thumbs.isOn;
            
        }

        private void Load_START()
        {
            Debug.Log("Load Scene_MainMenu");
            Debug.Log(Script_GlobalVars.Instance.useThumbSticks);
            SceneManager.LoadScene("Scene_MainMenu");
        }

        private void musicChange()
        {
            Script_GlobalVars.Instance.musicControl.volume = slider.value;
        }
    }
}
