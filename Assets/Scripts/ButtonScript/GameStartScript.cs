using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ButtonScript
{
    public class GameStartScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var btn = gameObject.GetComponent<Button>();
        
            btn.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
