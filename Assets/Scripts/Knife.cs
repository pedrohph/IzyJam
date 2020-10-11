using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public delegate void KnifeHitObject(bool isTarget);
    public event KnifeHitObject HitObject;


    [SerializeField] float speedForce = 10;
    Rigidbody2D rBody;
    bool hitSomething = false;
    // Start is called before the first frame update
    void Start() {
        KnifeSkin skins = Resources.Load<KnifeSkin>("KnifeSkins");
        gameObject.GetComponent<SpriteRenderer>().sprite = skins.spriteKnife[PlayerPrefs.GetInt("CurrentSkin", 0)];
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
        if (!hitSomething) {
            hitSomething = true;
            if (collision.gameObject.GetComponent<Target>()) {
                rBody.isKinematic = true;
                gameObject.transform.parent = collision.transform;
                transform.Translate(0, 0.75f, 0);
                collision.gameObject.GetComponent<Target>().TargetHit(collision.contacts[0].point);
            } else {
                gameObject.GetComponent<Collider2D>().enabled = false;
                rBody.AddForce(Vector2.one * -1 * speedForce / 2);
                Destroy(gameObject, 2);
            }
        }
        Destroy(this);
    }
}
