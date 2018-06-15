using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {
    public float positionY;
    LevelManager lm;
    GameObject plate;
    Rigidbody2D rb;
    BoxCollider2D bx;
    public bool caught;
    float dropSpeed;
    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        caught = false;
        dropSpeed = 3 + (GameManager.level - 1) * 0.3f;
        plate = GameObject.Find("BottomBun");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, dropSpeed * -1);
        bx = GetComponent<BoxCollider2D>();
        lm = FindObjectOfType<LevelManager>();
        transform.localScale = new Vector3(2 - (GameManager.level - 1)*0.13f, transform.localScale.y, 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        lm.sprites = sprites;
	}
	
	// Update is called once per frame
	void Update () {
        if (caught)
        {
            transform.position = new Vector3(plate.transform.position.x, transform.position.y, transform.position.z);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!caught)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ingredient")
            {
                if(gameObject.GetComponent<SpriteRenderer>().sprite.name == "top_bun_icon")
                {
                    lm.endGame(false);
                }
                if(lm.burgerStack.Count != 0)
                {
                    transform.position = new Vector3(lm.burgerStack[lm.burgerStack.Count - 1].transform.position.x, lm.burgerStack[lm.burgerStack.Count - 1].transform.position.y + bx.size.y, lm.burgerStack[lm.burgerStack.Count -1].transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(plate.transform.position.x, plate.transform.position.y + bx.size.y / 2, plate.transform.position.z);
                }

                Destroy(rb);
                caught = true;
                lm.burgerStack.Add(this);
            }
        }
    }
}
