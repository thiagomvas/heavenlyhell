using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum  ProjType { enemy, player }
    [SerializeField] private ProjType type;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    public Vector3 shootDir;
    [SerializeField] private GameObject purifyVFX;
    [SerializeField] private GameObject purified;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float timer;
    private void Update()
    {
        transform.position += shootDir * speed * Time.deltaTime;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ProjType.enemy && collision.CompareTag("Halo"))
        {
            collision.GetComponent<haloDeflect>().Deflect();
            Destroy(this.gameObject);
        }

        if (type == ProjType.enemy && collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Die();
            Destroy(this.gameObject);
        }

        if(type == ProjType.player && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Purify();
            Destroy(this.gameObject);
            GameObject vfx = Instantiate(purifyVFX, this.transform.position, Quaternion.identity);
            Destroy(vfx, 2f);
            GameObject p = Instantiate(purified, this.transform.position, Quaternion.identity);
            Destroy(p, 1f);
            PointsSystem.instance.points++;
        }

    }
}
