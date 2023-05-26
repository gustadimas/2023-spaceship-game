using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed;

    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * laserSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
