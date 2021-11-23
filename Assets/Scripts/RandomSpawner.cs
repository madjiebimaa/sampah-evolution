using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float respawnTime = 1.0f;
    // public GameObject Environment;
    // private GameObject MyNewEnvironment;
    // private float width;
    // private float height;
    // private RectTransform rt;
    private Vector2 screenBounds;

    private void Start() {
        // MyNewEnvironment = Instantiate(Environment) as GameObject;

        // rt = MyNewEnvironment.transform as RectTransform;
        // width = rt.rect.width;
        // height = rt.rect.height;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(width, height));
        StartCoroutine(Spawner());    
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(ItemPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x) , Random.Range(-screenBounds.y,  screenBounds.y));
    }
    IEnumerator Spawner()
    {   
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
