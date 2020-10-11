using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public GameObject slicedApple;
    public void OnTriggerEnter2D(Collider2D collision) {
        int coins = PlayerPrefs.GetInt("AppleCoin", 0);

        GameObject sliced = Instantiate(slicedApple, transform.position, transform.rotation);
        sliced.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(2, 5), 2), ForceMode2D.Impulse);
        Destroy(sliced, 1);

        sliced = Instantiate(slicedApple, transform.position, transform.rotation);
        sliced.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, -2), 2), ForceMode2D.Impulse);
        Destroy(sliced, 1);

        coins+=2;

        PlayerPrefs.SetInt("AppleCoin", coins);

        Destroy(gameObject);
    }
}
