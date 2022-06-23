using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS583
{
    public class Script_GlobalVars : MonoBehaviour
    {
        public float health;
        public string nameOne;
        public string nameTwo;
        public bool isTwoPlayer;
        public bool useThumbSticks;
        public int damage;
        public int colorOne;
        public int colorTwo;
        public static Script_GlobalVars Instance { get; private set; }
        public bool play;
        public AudioSource musicControl;
        public bool nextLevel;
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
                health = 100.0f;
                damage = 1;
                isTwoPlayer = false;
                useThumbSticks = false;
                nameOne = "player 1";
                nameTwo = "player 2";
                nextLevel = false;
                musicControl = GetComponent<AudioSource>();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        public float Health()
        {
            return health;
        }
    }
}
