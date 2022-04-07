using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{


    [SerializeField]
    public List<GameObject> EnemyTypes;

    private List<GameObject> enemyRows;
    private int stopCounter;

    void Awake()
    {
        stopCounter = 0;
        var children = GetComponentsInChildren<Transform>().ToList();
        enemyRows = children.FindAll((com) => com.name.Contains("Row")).Select(e => e.gameObject).ToList();

        enemyRows.ForEach((row) =>
        {
            Vector3 position = row.transform.position;
            Vector3 startPoint = position, endPoint = new Vector3(-1 * position.x, position.y, position.z);

            GameObject enemyType = EnemyTypes[Random.Range(0, EnemyTypes.Count)];
            Size enemySize = Utils.getSizeByCollider(enemyType);
            int Count = (int)(Mathf.Abs(position.x) * 1.5 / (enemySize.Width));
            for (int i = 0; i < Count; i++)
            {
                var enemy = Instantiate(enemyType, position, row.transform.rotation);
                enemy.transform.parent = row.transform;
                position = new Vector3(position.x + enemySize.Width * 1.5f, position.y, position.z);
            }
        });
    }

    void Update()
    {
        enemyRows.ForEach(row =>
        {
            row.GetComponent<Rigidbody2D>().velocity = stopCounter > 3 ? new Vector2(0, -0.25f) : Vector2.zero;
        });

        stopCounter++;
        if (stopCounter > 5) stopCounter = 0;
    }

}
