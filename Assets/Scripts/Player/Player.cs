using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] GameObject laser, gun, tripleLaser1, tripleLaser2;
    [SerializeField] float fireRate;
    float canShoot = 0.0f;
    bool tripleShoot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShipShooting();
        }
        
        ShipCameraLimit();
    }

    void ShipCameraLimit()
    {
        if (transform.position.y >= 0)
            transform.position = new Vector3(transform.position.x, 0, 0);

        if (transform.position.y <= -4.3f)
            transform.position = new Vector3(transform.position.x, -4.3f, 0);

        if (transform.position.x >= 8.1f)
            transform.position = new Vector3(8.1f, transform.position.y, 0);

        if (transform.position.x <= -4.3f)
            transform.position = new Vector3(-8.1f, transform.position.y, 0);
    }

    void ShipShooting()
    {
        if (Time.time > canShoot)
        {
            if (tripleShoot)
            {
                Instantiate(laser, new Vector2(tripleLaser1.transform.position.x, tripleLaser1.transform.position.y), tripleLaser1.transform.rotation);
                Instantiate(laser, new Vector2(tripleLaser2.transform.position.x, tripleLaser2.transform.position.y), tripleLaser2.transform.rotation);
            }            
        }
        else
        {
            Instantiate(laser, new Vector2(gun.transform.position.x, gun.transform.position.y), gun.transform.rotation);
        }
        canShoot = Time.time + fireRate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            if (collision.gameObject != null)
            {
                tripleShoot = true;
                Destroy(collision.gameObject);
                StartCoroutine("PowerUpTimesUp");
            }
        }
    }

    IEnumerator PowerUpTimesUp()
    {
        yield return new WaitForSeconds(5);
        tripleShoot = false;
    }
}
