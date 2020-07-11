using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowController : MonoBehaviour
{
    private float spawnX;
    private float spawnY;
    private float speed;
    private string type;

    // Start is called before the first frame update
    void Start()
    {
        type = "yellow";
        speed = 0.2f;
        int i = Random.Range(0, 2);
        speed = i == 0 ? speed : -speed;
        i = i == 0 ? -139 : 139;
        spawnX = i;
        transform.position = new Vector3(spawnX, -80f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0f, 0f);
        outOfBounds();
    }

    private void outOfBounds()
    {
        if (transform.position.x < -140 || transform.position.x > 140) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dude") {
            GameController.instance.loseLife();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
            if (type == collision.gameObject.GetComponent<BulletController>().type) {
                GameController.instance.addToScore(15);
                Destroy(this.gameObject);
            }
        }
    }
}