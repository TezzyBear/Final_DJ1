using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeController : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    [SerializeField]
    public List<GameObject> bulletList;
    private int dir;
    private float speed;
    private float jumpForce;
    private bool onFloor;

    // Start is called before the first frame update
    void Start()
    {
        dir = -1;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        speed = 100f;
        jumpForce = 200f;
        onFloor = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = body.velocity;
        vel.x = 0;
        body.velocity = vel;
        animator.SetBool("isRunning", false);
        if (Input.GetKeyDown(KeyCode.A)) {
            GameObject bulletObj = Instantiate(bulletList[0], this.transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().direction = dir;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            GameObject bulletObj = Instantiate(bulletList[1], this.transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().direction = dir;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            GameObject bulletObj = Instantiate(bulletList[2], this.transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().direction = dir;
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            GameObject bulletObj = Instantiate(bulletList[3], this.transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().direction = dir;
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            GameObject bulletObj = Instantiate(bulletList[4], this.transform.position, Quaternion.identity);
            bulletObj.GetComponent<BulletController>().direction = dir;
        }
        if (Input.GetKey(KeyCode.UpArrow) && onFloor) {
            onFloor = false;
            vel.y = jumpForce;
            body.velocity = vel;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            vel.x = -speed;
            body.velocity = vel;
            transform.localScale = new Vector2(40f, 40f);
            animator.SetBool("isRunning", true);
            dir = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            vel.x = speed;
            body.velocity = vel;
            transform.localScale = new Vector2(-40f, 40f);
            animator.SetBool("isRunning", true);
            dir = 1;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") {
            onFloor = true;
        }
    }
}
