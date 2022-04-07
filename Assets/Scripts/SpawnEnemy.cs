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
            Vector3 startPoint = position, endPoint = new Vector3(-1 * position.x, position.y, position.z);
            
            GameObject enemyType = EnemyTypes[Random.Range(0, EnemyTypes.Count)];
            Size enemySize = Utils.getSizeByCollider(enemyType);
            int Count = (int)(Mathf.Abs(position.x) * 2 / (enemySize.Width));
            for (int i = 0; i < Count; i++)
            {
                var enemy = Instantiate(enemyType, position,row.transform.rotation);
                enemy.transform.parent = row.transform;
                position = new Vector3(position.x + enemySize.Width * 1.15f, position.y, position.z);
            }
            
        });

    }

    // Update is called once per frame
    void Update()
    {
        enemyRows.ForEach(row =>
        {
            row.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.25f);
        });
    }
}
