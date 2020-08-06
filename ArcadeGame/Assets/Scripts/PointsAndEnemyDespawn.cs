using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndEnemyDespawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "EnemyDestroy")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Lava")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "PlayerCube")
        {
            Destroy(gameObject);
        }
    }
}
