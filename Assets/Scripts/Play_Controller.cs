using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


namespace CS583
{
    public class Play_Controller : MonoBehaviour
    {
        Vector2 inputs;
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
        public HealthBar healthBar;
        public Sprite[] playerSheet;
        private int count = 0;

        void Start()
        {
            
            player = GameObject.Find("Square_Player_1");
            controller = player.GetComponent<Rigidbody2D>();
            //healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
            healthBar.SetMaxHealth(health);
            if (Script_GlobalVars.Instance.colorOne == 0)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 1 sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }
            if (Script_GlobalVars.Instance.colorOne == 1)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 1 blue sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }
            if (Script_GlobalVars.Instance.colorOne == 2)
            {
                playerSheet = Resources.LoadAll<Sprite>("potato art 1 green sheet");
                player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
            }

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
                
                    if (Keyboard.current.dKey.IsPressed() && !goBack)
                    {

                        if (!goBack)
                        {
                            inputs.x = 1;
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
                    }
                        player.transform.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else if (Keyboard.current.aKey.IsPressed() && !goForward)
                    {
                        if (!goForward)
                        {
                            inputs.x = -1;
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
                    }
                        player.transform.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else
                    {
                        inputs.x = 0;
                    }
                    //inputs.x = Input.GetAxisRaw("Horizontal");
                    if (Keyboard.current.wKey.IsPressed() && !goDown)
                    {
                        if (!goDown)
                        {
                            inputs.y = 1;
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
                    }
                    }
                    //Input.GetAxisRaw("Verticle");
                    else if (Keyboard.current.sKey.IsPressed() && !goUp)
                    {
                        if (!goUp)
                        {
                            inputs.y = -1;
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
                    }
                    }
                    else
                    {
                        inputs.y = 0;
                    }


                    //if (inputs.magnitude > 0)
                    //{
                    Vector2 playerMovement = new Vector2(inputs.x, inputs.y);
                    if (inputs.x != 0)
                    {
                        playerMovement.x = inputs.x * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.x = 0f;
                    }
                    if (inputs.y != 0)
                    {
                        playerMovement.y = inputs.y * Time.deltaTime * playerSpeed;
                    }
                    else
                    {
                        playerMovement.y = 0f;
                    }
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
            Debug.Log("Collision");
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                if (!attacking)
                {
                    player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
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
                if (inputs.x > 0)
                {
                    goBack = true;
                    inputs.x = 0;
                    if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]))
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[5];
                    }
                    else if (player.transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[5]))
                    {
                        player.transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                    }
                }
                else if (inputs.x < 0)
                {
                    goForward = true;
                    inputs.x = 0;
                }
                if (inputs.y > 0)
                {
                    goDown = true;
                    inputs.y = 0;
                }
                else if (inputs.y < 0)
                {
                    goUp = true;
                    inputs.y = 0;
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
            /*
            else if (collision.gameObject.tag == "prop")
            {
                if (inputs.x > 0)
                {
                    goBack = true;
                    
                }
                else if (inputs.x < 0)
                {
                    goForward = true;
                    
                }
                if (inputs.y > 0)
                {
                    goDown = true;
                    
                }
                else if (inputs.y < 0)
                {
                    goUp = true;
                    
                }
            }
            */
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
            if (Keyboard.current.spaceKey.isPressed)
            {
                attacking = true;
            }
            else
            {
                attacking = false;
            }
        }



        public void Load_START()
        {
            Debug.Log("Load Scene_MainMenu");
            SceneManager.LoadScene("Scene_MainMenu");
        }

        public bool IsAttacking()
        {
            return attacking;
        }

    }
}
