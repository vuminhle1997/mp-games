using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Random = System.Random;

public class EnemyBehaviourScript : MonoBehaviour
{
    public GameObject SoundManager
    {
        get;
        set;
    }
    public float Hp
    {
        get;
        set;
    } = 3f;

    public AudioSource DeathSound
    {
        get;
        private set;
    }

    public float MSpeed
    {
        get;
        set;
    }

    private float OriginalSpeed;
    private int time = 2;

    public bool IsDead
    {
        set;
        get;
    } = false;

    private GameObject[] ChildrenNodes
    {
        get;
        set;
    }

    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        var random = new Random();
        var i = random.Next(0, SoundManager.GetComponent<DeathSoundManagerScript>().GetDeathSounds().Count);
        DeathSound = SoundManager.GetComponent<DeathSoundManagerScript>().GetDeathSounds()[i];
        ChildrenNodes = GameObject.FindGameObjectsWithTag(ObjectTags.NODE);
        MSpeed = 3.0f;
        OriginalSpeed = MSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = transform.forward * m_speed;
        var step = MSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, ChildrenNodes[_index].transform.position, step);
        if (transform.position == ChildrenNodes[_index].transform.position)
        {
            _index++;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(ObjectTags.GOAL))
        {
            Destroy(gameObject);
            Debug.Log("Touched goal");
        }

        if (collision.gameObject.tag.Equals(ObjectTags.BULLET))
        {
            var bullet = collision.gameObject.GetComponent<BulletBehaviourScript>();
            if (bullet.TowerType == TowerType.Slow)
            {
                MSpeed = 1.5f;
            }
        }
    }
}
