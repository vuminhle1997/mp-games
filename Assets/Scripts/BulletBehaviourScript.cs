using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourScript : MonoBehaviour
{
    public GameObject EnemyTarget
    {
        get;
        set;
    }

    public List<Collider> Enemies
    {
        get;
        set;
    }

    public Collider Collider
    {
        get;
        set;
    }

    public TowerType TowerType
    {
        get;
        set;
    }

    private Transform enemyTransform;
    private static double MAX_DISTANCE = 10f;
    private Vector3 position;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (EnemyTarget != null)
        {
            enemyTransform = EnemyTarget.transform;
            position = EnemyTarget.transform.position;
            transform.LookAt(position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyTarget == null) return;
        var step = Time.deltaTime * 15f;
        transform.Translate(0f, 0f, step);
    }

    private void FixedUpdate()
    {
        CheckDistanceAndDelete();
    }

    private void CheckDistanceAndDelete()
    {
        var currPosition = transform.position;
        var x = Math.Pow(currPosition.x - startPosition.x, 2);
        var y = Math.Pow(currPosition.y - startPosition.y, 2);
        var z = Math.Pow(currPosition.z - startPosition.z, 2);
        var distance = Math.Sqrt(x + y + z);
        if (distance > MAX_DISTANCE)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(ObjectTags.ENEMY))
        {
                Destroy(gameObject);
                var enemy = collision.gameObject.GetComponent<EnemyBehaviourScript>();
                enemy.Hp -= 1;
                if (enemy.Hp <= 0)
                {
                    enemy.IsDead = true;
                    Enemies.Remove(Collider);
                    enemy.DeathSound.Play();
                    enemy.MSpeed = 0f;
                    var clip = enemy.DeathSound.clip;
                    Destroy(collision.gameObject, clip.length);

                    var game = GameObject.FindGameObjectWithTag(ObjectTags.GAME);
                    if (game)
                    {
                        var state = game.GetComponent<PlayerStateScript>();
                        state.Coins += 5;
                        state.Score += 100;
                    }
                }
        }
    }
}
