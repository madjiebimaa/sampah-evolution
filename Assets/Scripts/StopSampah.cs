using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSampah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Sampah_5") || other.gameObject.CompareTag("Sampah_7") || other.gameObject.CompareTag("Sampah_15") || other.gameObject.CompareTag("Sampah_20") || other.gameObject.CompareTag("Sampah_50") || other.gameObject.CompareTag("Sampah_100") || other.gameObject.CompareTag("Battery"))
        {
            other.gameObject.SetActive(false);
            // other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
