using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public enum TowerType
{
    Normal,
    Slow
}

public class TowerBehaviourScript : MonoBehaviour
{
    [FormerlySerializedAs("_projectile")] [SerializeField] private GameObject projectile;

    [SerializeField] private int cost;
    [SerializeField] private TowerType towerType = TowerType.Normal;

    private readonly List<Collider> enemies = new List<Collider>();

    private int nextTime = 1;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            nextTime = Mathf.FloorToInt(Time.time) + 1;
            if (enemies.Count > 0)
            {
                // var enemy = enemies.FirstOrDefault(e => !e.gameObject.GetComponent<EnemyBehaviourScript>().IsDead);
                var e = enemies[0];
                if (e)
                {
                    if (e.gameObject.GetComponent<EnemyBehaviourScript>().IsDead)
                    {
                        enemies.Remove(e);
                    }
                    else
                    {
                        SpawnBullet(e);
                    }    
                }
                // TODO: fix here
                else
                {
                    var enemy = enemies.FirstOrDefault(e => !e.gameObject.GetComponent<EnemyBehaviourScript>().IsDead);
                    SpawnBullet(enemy);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(ObjectTags.ENEMY))
        {
            enemies.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemies.Contains(other))
        {
            enemies.Remove(other);
        }
    }

    private void SpawnBullet(Collider other)
    {
        var projectile = Instantiate(this.projectile, transform.position, Quaternion.identity);
        var script = projectile.GetComponent<BulletBehaviourScript>();
        script.TowerType = towerType;
        script.EnemyTarget = other.gameObject;
        script.Enemies = enemies;
        script.Collider = other;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetCost()
    {
        return cost;
    }
}
