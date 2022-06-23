using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CS583
{
    public class Enemy_Controller : MonoBehaviour
    {
        public Image healthbar;
        public Rigidbody2D controller;
        public GameObject player;
        public GameObject playerTwo;
        //public Play_Controller play_Controller;
        //public GameObject enemy;
        public bool clash;
        public float health = 2f;
        public HealthBar_Enemy enemy;
        public Text Name;
        public AudioSource musicControl;
        public Sprite[] playerSheet;
        private int count = 0;
        // Start is called before the first frame update
        void Start()
        {
            //enemy = GameObject.Find("Enemy");
            player = GameObject.Find("Square_Player_1");
            playerTwo = GameObject.Find("Square_Player_2");
            
            controller = transform.GetComponent<Rigidbody2D>();
            clash = false;
            enemy = GameObject.Find("HealthBar_Enemy").GetComponent<HealthBar_Enemy>();
            enemy.SetMaxHealth(health);
            Name = enemy.GetComponentInChildren<Text>();
            Name.text = "Grunt";
            musicControl = GetComponent<AudioSource>();
            playerSheet = Resources.LoadAll<Sprite>("enemy sheet");
            transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
        }

        // Update is called once per frame
        void Update()
        {
            if (Script_GlobalVars.Instance.isTwoPlayer)
            {
                if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = playerSheet[5];
                }
                else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[5]) && count == 0)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                }
                if (count < 3)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if ((player.transform.position - transform.position).magnitude < (playerTwo.transform.position - transform.position).magnitude)
                {
                    if ((player.transform.position - transform.position).magnitude > 0.5)
                    {
                        //Debug.Log((player.transform.position - transform.position).magnitude);
                        transform.position += (player.transform.position - transform.position).normalized * 2 * Time.deltaTime;
                    }
                }
                else if ((player.transform.position - transform.position).magnitude > (playerTwo.transform.position - transform.position).magnitude)
                {
                    if ((playerTwo.transform.position - transform.position).magnitude > 0.5)
                    {
                        transform.position += (playerTwo.transform.position - transform.position).normalized * 2 * Time.deltaTime;
                    }
                }
                else if ((player.transform.position - transform.position).magnitude == (playerTwo.transform.position - transform.position).magnitude)
                {
                    if ((player.transform.position - transform.position).magnitude > 0.5)
                    {
                        transform.position += (player.transform.position - transform.position).normalized * 4 * Time.deltaTime;
                    }
                }
            }
            else
            {
                if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = playerSheet[5];
                }
                else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[5]) && count == 0)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
                }
                if (count < 3)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if ((player.transform.position - transform.position).magnitude > 0.5)
                {
                    //Debug.Log((player.transform.position - transform.position).magnitude);
                    transform.position += (player.transform.position - transform.position).normalized * 2 * Time.deltaTime;
                }
            }
            if (player.GetComponent<Play_Controller>().IsAttacking())
            {
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else if (playerTwo.GetComponent<Play2_Controller>().IsAttacking())
            {
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                transform.position -= (transform.position).normalized * 2 * Time.deltaTime;
                clash = true;
                if (player.GetComponent<Play_Controller>().IsAttacking())
                {
                    //musicControl.PlayDelayed(1);
                    health -= 1 * Time.fixedDeltaTime;
                    enemy.SetHealth(health);
                }
                else if (playerTwo.GetComponent<Play2_Controller>().IsAttacking())
                {
                    //musicControl.PlayDelayed(1);
                    health -= 1 * Time.fixedDeltaTime;
                    enemy.SetHealth(health);
                }
                else
                {
                    if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[1];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[1]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[2];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[2]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[3];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[3]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[4];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[4]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
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
            else if (collision.gameObject.tag == "prop")
            {

            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (player.GetComponent<Play_Controller>().IsAttacking())
                {
                    musicControl.Play();
                    health -= 1 * Time.fixedDeltaTime;
                    enemy.SetHealth(health);
                }
                else if (playerTwo.GetComponent<Play2_Controller>().IsAttacking())
                {
                    musicControl.Play();
                    health -= 1 * Time.fixedDeltaTime;
                    enemy.SetHealth(health);
                }
                else
                {
                    if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[0]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[1];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[1]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[2];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[2]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[3];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[3]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[4];
                    }
                    else if (transform.GetComponent<SpriteRenderer>().sprite.Equals(playerSheet[4]) && count == 0)
                    {
                        transform.GetComponent<SpriteRenderer>().sprite = playerSheet[0];
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
        }

        private void OnCollisionExit2D(Collision2D collision)
        {

            clash = false;
        }
    }
}
