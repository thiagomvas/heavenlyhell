using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haloDeflect : MonoBehaviour
{
    [SerializeField] private GameObject proj;
    public void Deflect()
    {
        GameObject p = Instantiate(proj, this.transform.position, Quaternion.Euler(this.transform.forward));
        p.GetComponent<Projectile>().shootDir = -this.transform.up;
    }
}
