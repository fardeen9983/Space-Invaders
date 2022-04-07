using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField]
    public int SpawnCount;
    [SerializeField]
    public List<GameObject> EnemyTypes;

    private List<GameObject> enemyRows;

    // Start is called before the first frame update
    void Start()
    {
       

        var children = GetComponentsInChildren<Transform>().ToList();
        enemyRows = children.FindAll((com) => com.name.Contains("Row")).Select(e => e.gameObject).ToList();

        enemyRows.ForEach((row) =>
        {
            Vector3 position = row.transform.position;
            GameObject enemyType = EnemyTypes[Random.Range(0, EnemyTypes.Count)];
            for(int i = 0; i < SpawnCount; i++)
            {
                Instantiate(enemyType, position,row.transform.rotation);
            }
            
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
