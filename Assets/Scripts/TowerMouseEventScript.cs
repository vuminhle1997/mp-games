using UnityEngine;
using UnityEngine.UI;

public class TowerMouseEventScript : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject prefab;
    private PlayerStateScript state;

    private void Awake()
    {
        if (game != null)
        {
            state = game.GetComponent<PlayerStateScript>();
        }
    }
    
    void Start()
    {
        var btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(ClickEvent);
    }
    
    private void ClickEvent()
    {
        state.SelectedTower = prefab;
    }
}
