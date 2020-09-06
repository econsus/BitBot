using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private GameObject target;
    public float speed = 4;
    public float stopdistance = 10;
    public float retreatdistance = 6;
    private CircleCollider2D range;
    [SerializeField] private bool inRange;
    void Start()
    {
        target = GameObject.Find("Player");
        range = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (inRange == true)
        {
            if (Vector2.Distance(transform.position, target.transform.position) > stopdistance)
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
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            inRange = false;
        }
    }
}
