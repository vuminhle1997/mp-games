using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("_enemyPrefab")] [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject soundManager;
    private bool _spawn = false;
    private bool hasStarted = false;
    private int _enemyCount = 0;

    // Update is called once per frame
    void Update()
    {
        var nodes = GameObject.FindGameObjectsWithTag(ObjectTags.TOWER);
        if (nodes.Length > 0)
        {
            _spawn = true;
            if (!hasStarted) StartCoroutine(SpawnEnemy());
            hasStarted = true;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (_spawn)
        {
            var f = (float) _enemyCount / 50;
            var percentage = 1 + f;
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            var script = enemy.GetComponent<EnemyBehaviourScript>();
            script.SoundManager = soundManager;
            script.Hp *= percentage;
            script.MSpeed *= f;
            _enemyCount++;
            yield return new WaitForSeconds(1.9f);
        }
    }
}
