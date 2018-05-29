using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour {
    public int speed;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (GameManager.level != 0)
        {
            transform.localScale = new Vector3(1.7f - 0.1f * GameManager.level, transform.localScale.y, transform.localScale.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(speed*-1, 0);
        }else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
	}
}
