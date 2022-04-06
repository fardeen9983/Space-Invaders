using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControll : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x, position.y - 0.001f, position.z);
    }
}
