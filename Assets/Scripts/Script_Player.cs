using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS583
{
    public class Script_Player : MonoBehaviour
    {
        public static Script_Player Instance { get; private set; }
        public string Name;
        public string Alignment;
        public string Race;
        public string ChrClass;
        public int Exp_Current;
        public int Exp_Max;
        public int HP_Current;
        public int HP_Max;
        public int ArmorClass;
        public int SpeedWalking;
        public int SpeedRunning;
        public int HeightJumping;
        public float Strenght, Dexterity, Constitution, Intelligence, Wisdom, Charisma;
        public List<string> items;
        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
