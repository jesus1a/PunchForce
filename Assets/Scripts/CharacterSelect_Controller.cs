using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CS583 {
    public class CharacterSelect_Controller : MonoBehaviour
    {
        public Button button_Quit;
        public Button Button_StartP1;
        public Button Button_StartP2;
        public Image imageOne;
        public InputField NameOne;
        public InputField NameTwo;
        public Dropdown diff;
        public Dropdown colorOne;
        public Dropdown colorTwo;
        // Start is called before the first frame update
        void Start()
        {
            button_Quit = GameObject.Find("Button_Back").GetComponent<Button>();
            Button_StartP1 = GameObject.Find("Button_P1").GetComponent<Button>();
            Button_StartP2 = GameObject.Find("Button_P2").GetComponent<Button>();
            NameOne = GameObject.Find("InputField_Name").GetComponent<InputField>();
            NameTwo = GameObject.Find("InputField_NameTwo").GetComponent<InputField>();
            diff = GameObject.Find("Dropdown_Difficulty").GetComponent<Dropdown>();
            colorOne = GameObject.Find("Dropdown_P1").GetComponent<Dropdown>();
            colorTwo = GameObject.Find("Dropdown_P2").GetComponent<Dropdown>();
            button_Quit.onClick.AddListener(LoadMM);
            Button_StartP1.onClick.AddListener(Load1P);
            Button_StartP2.onClick.AddListener(Load2P);
            diff.onValueChanged.AddListener(delegate {diffSave(); });
            colorOne.onValueChanged.AddListener(delegate { playerOneColor(); });
            colorTwo.onValueChanged.AddListener(delegate { playerTwoColor(); });
            Button_StartP2.interactable = false;
            NameOne.onEndEdit.AddListener(delegate { saveNameOne(); });
            NameTwo.onEndEdit.AddListener(delegate { saveNameTwo(); });

        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(Gamepad.current);
            if (Gamepad.current != null)
            {
                if (Gamepad.current.aButton.wasPressedThisFrame)
                {
                    Button_StartP2.interactable = true;
                    Text text = GameObject.Find("Text_P2Information").GetComponent<Text>();
                    text.enabled = false;
                }
            }
            //Debug.Log(colorTwo.value.ToString());
        }

        private void saveNameOne()
        {
            Script_GlobalVars.Instance.nameOne = NameOne.text;
        }

        private void saveNameTwo()
        {
            Script_GlobalVars.Instance.nameTwo = NameTwo.text;
        }

        private void LoadMM()
        {
            Debug.Log("Load Main Menu");
            SceneManager.LoadScene("Scene_MainMenu");
        }

        private void Load1P()
        {
            Debug.Log("Load Level 1");
            Script_GlobalVars.Instance.isTwoPlayer = false;
            SceneManager.LoadScene("Scene_LevelOne");
        }

        private void Load2P()
        {
            Debug.Log("Load Level 1 with 2 players");
            Script_GlobalVars.Instance.isTwoPlayer = true;
            SceneManager.LoadScene("Scene_LevelOne");
        }

        private void diffSave()
        {
            Script_GlobalVars.Instance.damage = diff.value;
        }

        private void playerOneColor()
        {
            Script_GlobalVars.Instance.colorOne = colorOne.value;
            Image player = GameObject.Find("Image_P1").GetComponent<Image>();
            if (colorOne.value == 0)
            {
                player.sprite = Resources.Load<Sprite>("potato art 1");
            }
            if (colorOne.value == 1)
            {
                player.sprite = Resources.Load<Sprite>("potato art 1 red");
            }
            if (colorOne.value == 2)
            {
                player.sprite = Resources.Load<Sprite>("potato art 1 green");
            }

        }

        private void playerTwoColor()
        {
            Script_GlobalVars.Instance.colorTwo = colorTwo.value;
            Image player = GameObject.Find("Image_P2").GetComponent<Image>();
            if (colorTwo.value == 0)
            {
                player.sprite = Resources.Load<Sprite>("potato art 2");
            }
            if (colorTwo.value == 1)
            {
                player.sprite = Resources.Load<Sprite>("potato art 2 blue");
            }
            if (colorTwo.value == 2)
            {
                player.sprite = Resources.Load<Sprite>("potato art 2 green");
            }
        }
    }
}
