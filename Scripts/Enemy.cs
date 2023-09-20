using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    [SerializeField] private GameObject proj;
    [SerializeField] private float speed;
    [SerializeField] private float shootDelay;

    float timer;
    float nextShoot;
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        nextShoot = shootDelay;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= nextShoot)
        {
            nextShoot = timer + shootDelay;
            Debug.Log("Should Shoot");
            Shoot();
        }


        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }


    private void Shoot()
    {
        GameObject p = Instantiate(proj, this.transform.position, Quaternion.identity);
        p.GetComponent<Projectile>().shootDir = (player.transform.position - transform.position).normalized;
    }

    public void Purify()
    {
        SoundManager.instance.PlayPurify();
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}
