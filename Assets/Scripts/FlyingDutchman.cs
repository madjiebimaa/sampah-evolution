using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDutchman : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector3 screenBounds;

    private void Start() { 
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private void Update() {
        if(transform.position.x < screenBounds.x - 100)
        {
            Destroy(this.gameObject);
        }
    }
}

    