using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        Invoke("PowerUp", 1f);
    }

    void PowerUp()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed * Time.deltaTime);
    }
}
