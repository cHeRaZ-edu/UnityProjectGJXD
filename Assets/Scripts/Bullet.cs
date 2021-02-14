using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10.0f;
    public Vector3 direction = new Vector3(1,0,0);
    public float speed = 3.0f;
    private SpriteRenderer sp;
    private bool isDestory = false;
    private void Start() {
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update() {
        if(direction.x > 0) {
            sp.flipX = false;
        } else if(direction.x < 0) {
            sp.flipX = true;
        }
        transform.position += direction * speed * Time.deltaTime;
        if(isDestory)
            DestroyImmediate(gameObject, true);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.Damage(damage);
            isDestory = true;
        }
        if(other.gameObject.isStatic)
            isDestory = true;
    }
}
