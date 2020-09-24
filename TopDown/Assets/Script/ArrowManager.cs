using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag != "Player")
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().Die();
            }
            Destroy(gameObject);
        }

    }
}
