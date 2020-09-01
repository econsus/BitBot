using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooting : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;
    private GameObject bulletspawn;
    [SerializeField] private float timeBtwShots;
    [SerializeField] private bool inRange;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bulletspawn = this.gameObject;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {

        if(inRange == true)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(bullet, bulletspawn.transform.position, Quaternion.Euler(0, 0, findAngle()));
                timeBtwShots = startTimeBtwShots;

            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
    float findAngle()
    {
        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;
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
