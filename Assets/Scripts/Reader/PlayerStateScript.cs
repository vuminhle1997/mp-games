using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Hp
    {
        get;
        set;
    } = 3f;

    public int Score
    {
        get;
        set;
    } = 0;

    public int Coins
    {
        get;
        set;
    } = 50;

    public GameObject SelectedTower
    {
        get;
        set;
    }

    private void Update()
    {
        if (Hp <= 0f)
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Points", Score);
            PlayerPrefs.SetFloat("HP", Hp);
            PlayerPrefs.SetInt("Coins", Coins);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOverScreen");
        }

        if (Camera.main)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                var hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    if (IsAllowedToPlace(hit))
                    {
                        Coins -= SelectedTower.GetComponent<TowerBehaviourScript>().GetCost();
                        Instantiate(SelectedTower, hit.point, Quaternion.identity);
                        SelectedTower = null;
                    } 
                }
            }
        }
    }

    private bool IsAllowedToPlace(RaycastHit hit)
    {
        if (SelectedTower != null)
        {
            var script = SelectedTower.GetComponent<TowerBehaviourScript>();
            if (hit.collider.gameObject.tag.Equals(ObjectTags.OBSTACLE) &&
                (Coins - script.GetCost()) >= 0) return true;
        }

        return false;
    }
}
