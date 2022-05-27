using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Reader
{
    public class GameOverStateReaderScript : MonoBehaviour
    {
        [SerializeField] private StateReaderEnum choice;
        private TextMeshPro text;
        private int Points;
        private float Hp;
        private int Coins;
        
        void Start()
        {
            text = gameObject.GetComponent<TextMeshPro>();
            Points = PlayerPrefs.GetInt("Points");
            Hp = PlayerPrefs.GetFloat("HP");
            Coins = PlayerPrefs.GetInt("Coins");
        }

        // Update is called once per frame
        void Update()
        {
            switch (choice)
            {
                case StateReaderEnum.Hp:
                    text.text = $"HP: {Hp}";
                    break;
                case StateReaderEnum.Coins:
                    text.text = $"Coins: {Coins}";
                    break;
                case StateReaderEnum.Score:
                    text.text = $"Score: {Points}";
                    break;
            }
        }
    }

}