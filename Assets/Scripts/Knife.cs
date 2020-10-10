using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public delegate void KnifeHitObject(bool isTarget);
    public event KnifeHitObject HitObject;


    [SerializeField] float speedForce = 10;
    Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start() {
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Criar classe de controladores depois
        if (Input.anyKeyDown) {
            ThrowKnife();
        }
    }

    public void ThrowKnife() {
        rBody.AddForce(Vector2.up * speedForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (HitObject != null) {
            HitObject(collision.gameObject.GetComponent<Target>() != null);
        }

        if (collision.gameObject.GetComponent<Target>()) {
            gameObject.transform.parent = collision.transform;
            rBody.isKinematic = true;
            transform.Translate(0, 0.5f, 0);
            Destroy(this);
        } else{
            Destroy(gameObject);
        }
    }
}
