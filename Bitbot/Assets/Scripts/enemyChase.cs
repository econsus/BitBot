using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public GameObject target;
    public float speed = 4;
    public float stopdistance = 10;
    public float retreatdistance = 6;

    public
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > stopdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > retreatdistance && Vector2.Distance(transform.position, target.transform.position) < stopdistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime * -1);
        }
    }
}
