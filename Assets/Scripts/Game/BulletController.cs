using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public string type;
    private float speed;
    [HideInInspector]
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * direction, 0f, 0f);
        outOfBounds();
    }

    private void outOfBounds()
    {
        if (transform.position.x < -140 || transform.position.x > 140) {
            Destroy(this.gameObject);
        }
    }
}