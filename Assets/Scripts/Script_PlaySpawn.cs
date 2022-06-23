using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace CS583
{
    public class Script_PlaySpawn : MonoBehaviour
    {
        public Button quit;
        public Button reset;
        public Button next;
        public GameObject panel;
        public GameObject playerTwo;
        public GameObject healthpanelTwo;
        public GameObject healthpanelOne;
        public Play_Controller controllerOne;
        public Play2_Controller controllerTwo;
        public GameObject[] enemys;
        
        // Start is called before the first frame update
        void Start()
        {
            panel = GameObject.Find("Panel");
            controllerTwo = GameObject.Find("Square_Player_2").GetComponent<Play2_Controller>();
            healthpanelTwo = GameObject.Find("HealthBarP2");
            healthpanelOne = GameObject.Find("HealthBar");
            playerTwo = GameObject.Find("Square_Player_2");
            healthpanelTwo.GetComponentInChildren<Text>().text = Script_GlobalVars.Instance.nameTwo;
            healthpanelOne.GetComponentInChildren<Text>().text = Script_GlobalVars.Instance.nameOne;
            playerTwo.SetActive(false);
            healthpanelTwo.SetActive(false);
            reset = GameObject.Find("Button_Reset").GetComponent<Button>();
            quit = GameObject.Find("Button_Quit").GetComponent<Button>();
            next = GameObject.Find("Button_NextLevel").GetComponent<Button>();
            reset.onClick.AddListener(realoadScene);
            quit.onClick.AddListener(loadMM);
            
            Script_GlobalVars.Instance.nextLevel = false;
            panel.SetActive(false);
            controllerOne = GameObject.Find("Square_Player_1").GetComponent<Play_Controller>();
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (Script_GlobalVars.Instance.isTwoPlayer)
            {
                playerTwo.SetActive(true);
                healthpanelTwo.SetActive(true);
            }

            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (Script_GlobalVars.Instance.isTwoPlayer)
            {
                if (controllerOne.health < 0 && controllerTwo.health < 0)
                {
                    panel.SetActive(true);
                    /*
                    reset = GameObject.Find("Button_Reset").GetComponent<Button>();
                    quit = GameObject.Find("Button_Quit").GetComponent<Button>();
                    reset.onClick.AddListener(realoadScene);
                    quit.onClick.AddListener(loadMM);
                    */
                }
            }
            else
            {
                if (controllerOne.health < 0)
                {
                    panel.SetActive(true);
                    /*
                    buttonOne = GameObject.Find("Button_Reset").GetComponent<Button>();
                    buttonTwo = GameObject.Find("Button_Quit").GetComponent<Button>();
                    buttonOne.onClick.AddListener(realoadScene);
                    buttonTwo.onClick.AddListener(loadMM);
                    */
                }
            }
            if (Keyboard.current.escapeKey.isPressed)
            {
                Script_GlobalVars.Instance.nextLevel = false;
                loadMM();
            }
            if (enemys.Length == 0)
            {
                panel.SetActive(true);
                next.onClick.AddListener(loadNL);
                reset.onClick.AddListener(realoadScene);
                quit.onClick.AddListener(loadMM);
                
                Script_GlobalVars.Instance.nextLevel = true;
            }
            //Debug.Log(enemys.Length);
        }

        private void realoadScene()
        {
            panel.SetActive(false);
            Debug.Log("Realoading Scene");
            Script_GlobalVars.Instance.nextLevel = false;
            if (SceneManager.GetActiveScene().name.Equals("Scene_LevelOne"))
            {
                SceneManager.LoadScene("Scene_LevelOne");
            }
            else if (SceneManager.GetActiveScene().name.Equals("Scene_LevelTwo"))
            {
                SceneManager.LoadScene("Scene_LevelTwo");
            }
        }

        private void loadMM()
        {
            //panel.SetActive(false);
            Debug.Log("Load Main Menu");
            Script_GlobalVars.Instance.nextLevel = false;
            SceneManager.LoadScene("Scene_MainMenu");
        }

        private void loadNL()
        {
            //panel.SetActive(false);
            Script_GlobalVars.Instance.nextLevel = false;
            if (SceneManager.GetActiveScene().name.Equals("Scene_LevelOne"))
            {
                SceneManager.LoadScene("Scene_LevelTwo");
            }
            else if (SceneManager.GetActiveScene().name.Equals("Scene_LevelTwo"))
            {
                SceneManager.LoadScene("Scene_Credits");
            }
        }
    }
}