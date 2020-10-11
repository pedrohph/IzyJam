using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public delegate void KnifeHitObject(bool isTarget);
    public event KnifeHitObject HitObject;

    [SerializeField] float speedForce = 10;
    Rigidbody2D rBody;
    AudioSource audioSource;
    public AudioClip[] impactAudio = new AudioClip[2];

    bool hitSomething = false;

    // Start is called before the first frame update
    void Start() {
        KnifeSkin skins = Resources.Load<KnifeSkin>("KnifeSkins");
        gameObject.GetComponent<SpriteRenderer>().sprite = skins.spriteKnife[PlayerPrefs.GetInt("CurrentSkin", 0)];
        rBody = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
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
            gameObject.layer = LayerMask.NameToLayer("Target");

            hitSomething = true;
            if (collision.gameObject.GetComponent<Target>()) {
                audioSource.clip = impactAudio[0];

                rBody.isKinematic = true;

                gameObject.transform.parent = collision.transform;
                transform.Translate(0, 0.75f, 0);

                collision.gameObject.GetComponent<Target>().TargetHit(collision.contacts[0].point);
            } else {
                audioSource.clip = impactAudio[1];
                gameObject.GetComponent<Collider2D>().enabled = false;
                rBody.velocity = new Vector2(rBody.velocity.x, 0);
                rBody.gravityScale = 2;
                Destroy(gameObject, 2);
            }
            audioSource.Play();
        }
        Destroy(this);
    }
}
