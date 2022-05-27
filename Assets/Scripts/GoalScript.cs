using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject game;
    private PlayerStateScript playerState;

    private void Awake()
    {
        playerState = game.GetComponent<PlayerStateScript>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(ObjectTags.ENEMY))
        {
            playerState.Hp -= 1f;
        }
    }
}
