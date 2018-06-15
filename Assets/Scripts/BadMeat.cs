using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMeat : MonoBehaviour {

    public float positionY;
    LevelManager lm;
    GameObject plate;
    Rigidbody2D rb;
    float dropSpeed;
    // Use this for initialization
    void Start()
    {
        dropSpeed = 3 + (GameManager.level - 1) * 0.2f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, dropSpeed * -1);
        lm = FindObjectOfType<LevelManager>();
        transform.localScale = new Vector3(0.7f, 0.7f, 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lm.endGame(true);
        }
        else if (other.gameObject.GetComponent<Ingredient>().caught)
        {
            lm.endGame(true);
        }
    }
}
