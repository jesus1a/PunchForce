using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace CS583
{
    public class Play2_Controller : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector2 inputs;
        Vector2 ThumbInputs;
        public Button Button_Menu;
        public float playerSpeed = 3.0f;
        public GameObject player;
        public Rigidbody2D controller;
        public bool goBack = false;
        public bool goForward = false;
        public bool goUp = false;
        public bool goDown = false;
        public float health = 100f;
        bool attacking = false;
        public HealthBarTwo healthBar;
        public Sprite[] playerSheet;
        private int count = 0;
        void Start()
        {
            player = GameObject.Find("Square_Player_2");
            controller = player.GetComponent<Rigidbody2D>();
            healthBar = GameObject.Find("HealthBarP2").GetComponent<HealthBarTwo>();
            healthBar.SetMaxHealth(health);

            if (Script_GlobalVars.Instance.colorTwo == 0)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 2 sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }
            if (Script_GlobalVars.Instance.colorTwo == 1)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 2 blue sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }
            if (Script_GlobalVars.Instance.colorTwo == 2)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 2 green sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }
            //playerControls = new PlayerControls();

        }

        private void FixedUpdate()
        {
            if (health > 0 && !Script_GlobalVars.Instance.nextLevel)
            {
                if (health < 100)
                {
                    health += 1 * Time.deltaTime;
                    healthBar.SetHealth(health);
                }

                ThumbInputs.x = Gamepad.current.leftStick.x.ReadValue();
                    ThumbInputs.y = Gamepad.current.leftStick.y.ReadValue();
                    inputs.x = Gamepad.current.dpad.x.ReadValue();
                    inputs.y = Gamepad.current.dpad.y.ReadValue();
                    if (Gamepad.current.leftStick.x.ReadValue() > 0 || Gamepad.current.dpad.x.ReadValue() > 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        player.transform.GetComponent<SpriteRenderer>().flipX = true;
                    }
                
                
                //if (inputs.magnitude > 0)
                //{
                Vector2 playerMovement = new Vector2(inputs.x, inputs.y);
                if (inputs.x != 0)
                {
                    if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[5];
                        
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[5]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                    }
                    if (count < 3)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                        if (!goBack && inputs.x > 0)
                    {
                        playerMovement.x = inputs.x * Time.deltaTime * playerSpeed;
                    }
                    else if (!goForward && inputs.x < 0)
                    {
                        playerMovement.x = inputs.x * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.x = 0f;
                    }
                }
                else if (ThumbInputs.x != 0)
                {
                    if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[5];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[5]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                    }
                    if (count < 3)
                    {
                        count++;
                    }
                    if (!goBack && ThumbInputs.x > 0)
                    {
                        playerMovement.x = ThumbInputs.x * Time.deltaTime * playerSpeed;
                    }
                    else if(!goForward && ThumbInputs.x < 0)
                    {
                        playerMovement.x = ThumbInputs.x * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.x = 0f;
                    }
                }
                else
                {
                    playerMovement.x = 0f;
                }
                if (inputs.y != 0)
                {
                    if (!goUp && inputs.y < 0)
                    {
                        playerMovement.y = inputs.y * Time.deltaTime * playerSpeed;
                        //Debug.Log(playerMovement.y);
                    }
                    else if (!goDown && inputs.y > 0)
                    {
                        playerMovement.y = inputs.y * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.y = 0f;
                    }
                }
                
                else if (ThumbInputs.y != 0)
                {
                    
                    if (!goUp && ThumbInputs.y < 0)
                    {
                        
                        playerMovement.y = ThumbInputs.y * Time.deltaTime * playerSpeed;
                        //Debug.Log(playerMovement.y);
                    }
                    else if (!goDown && ThumbInputs.y > 0)
                    {
                        playerMovement.y = ThumbInputs.y * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.y = 0f;
                    }
                }
                else
                {
                    playerMovement.y = 0f;
                }
                //Debug.Log(playerMovement.y);
                controller.MovePosition(controller.position + playerMovement);
            }
        }
        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //health -= 1 * Time.deltaTime;
            Debug.Log("Collision");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            if (health < 100)
            {
                health += 1 * Time.deltaTime;
            }
        }
        */
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Debug.Log("Collision");

                if (!attacking)
                {
                    health -= (Script_GlobalVars.Instance.damage + 1) * 10 * Time.deltaTime;
                    //controller.MovePosition(controller.position - new Vector2(5,5));
                }
                else
                {
                    if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[1];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[1]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[2];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[2]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[3];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[3]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[4];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[4]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                    }
                    if (count < 3)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                healthBar.SetHealth(health);
            }
            else if (collision.gameObject.tag == "prop")
            {
                if (inputs.x > 0 || ThumbInputs.x > 0)
                {
                    goBack = true;
                    inputs.x = 0;
                    ThumbInputs.x = 0;
                }
                else if (inputs.x < 0 || ThumbInputs.x < 0)
                {
                    goForward = true;
                    inputs.x = 0;
                    ThumbInputs.x = 0;
                }
                if (inputs.y > 0 || ThumbInputs.y > 0)
                {
                    goDown = true;
                    inputs.y = 0;
                    ThumbInputs.y = 0;
                }
                else if (inputs.y < 0 || ThumbInputs.y < 0)
                {
                    goUp = true;
                    inputs.y = 0;
                    ThumbInputs.y = 0;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                if (!attacking)
                {
                    health -= (Script_GlobalVars.Instance.damage + 1) * 10 * Time.deltaTime;
                    //controller.MovePosition(controller.position - new Vector2(5,5));
                }
                else
                {
                    if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[1];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[1]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[2];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[2]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[3];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[3]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[4];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[4]) && count == 0)
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                    }
                    if (count < 3)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                healthBar.SetHealth(health);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            goBack = false;
            goForward = false;
            goUp = false;
            goDown = false;
        }
        // Update is called once per frame
        void Update()
        {
            /*
            if (!false)
            {
                Debug.Log("Collision");
                if (Script_GlobalVars.Instance.Health() < 100)
                {
                    health += 1 * Time.deltaTime;
                }
            }
            else
            {
                health -= 1 * Time.deltaTime;
            }

            */

            //}
            //healthbar.fillAmount = health / 100;
            if (Gamepad.current.xButton.isPressed)
            {
                attacking = true;
            }
            else
            {
                attacking = false;
            }
        }


        /*
        public void Load_START()
        {
            Debug.Log("Load Scene_MainMenu");
            SceneManager.LoadScene("Scene_MainMenu");
        }
        */

        public bool IsAttacking()
        {
            return attacking;
        }

    }
}
