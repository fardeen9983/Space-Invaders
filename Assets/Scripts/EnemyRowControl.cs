using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRowControl : MonoBehaviour
{
    private int direction;
    private List<GameObject> enemies;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(direction, 0);
        Debug.Log("Direction" + direction);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Boundary")
        {
            direction *= -1;
            transform.position = new Vector2(transform.position.x, transform.position.y - Utils.getSizeByCollider(gameObject).Height / 2);
        }
    }

}
