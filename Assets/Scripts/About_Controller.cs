using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CS583
{
    public class About_Controller : MonoBehaviour
    {
        public Button button_Quit;
        // Start is called before the first frame update
        void Start()
        {
            button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
            button_Quit.onClick.AddListener(Load_START);
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void Load_START()
        {
            Debug.Log("Load Scene_MainMenu");
            Debug.Log(Script_GlobalVars.Instance.useThumbSticks);
            SceneManager.LoadScene("Scene_MainMenu");
        }
    }
}
