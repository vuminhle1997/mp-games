using UnityEngine;
using UnityEngine.UI;

namespace Reader
{
    public enum StateReaderEnum
    {
        Hp,
        Score,
        Coins
    }
    public class StateReader : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject game;
        [SerializeField] private StateReaderEnum choice;
        private Text text;
        private PlayerStateScript playerState;
        void Start()
        {
            text = gameObject.GetComponent<Text>();
            playerState = game.GetComponent<PlayerStateScript>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (choice)
            {
                case StateReaderEnum.Hp:
                    text.text = $"HP: {playerState.Hp}";
                    break;
                case StateReaderEnum.Coins:
                    text.text = $"Coins: {playerState.Coins}";
                    break;
                case StateReaderEnum.Score:
                    text.text = $"Score: {playerState.Score}";
                    break;
            }
        }
    }

}