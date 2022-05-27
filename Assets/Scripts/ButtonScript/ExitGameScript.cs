using UnityEngine;
using UnityEngine.UI;

namespace ButtonScript
{
    public class ExitGameScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
