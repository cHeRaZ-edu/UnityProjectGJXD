using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public bool isAttack = false;
    public const float shootTime = 1.5f;
    private float time;
    public float health = 100;
    public float timeDestory = 1.0f;
    public Vector3 direction = new Vector3(1,0,0);
    private ZoneDamage zone;
    public GameObject bulletinstante;
    public Transform targetRespawnBullet;
    // Start is called before the first frame update
    void Start() {
        time = shootTime;
        foreach (Transform child in transform) {
            if(child.gameObject.tag == "Zone") {
                zone = child.GetComponent<ZoneDamage>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack || zone.target) {
            time -= Time.deltaTime;
            if(time < 0) {
                time = shootTime;
                Fire();
            }
        }
        if (health < 0)
        {
            timeDestory -= Time.deltaTime;
            if (timeDestory < 0)
            {
                DestroyImmediate(gameObject, true);
            }
        }
    }
    void Fire() {
        Debug.Log("Fire ...");
        GameObject bullet = GameObject.Instantiate(bulletinstante);
        bullet.transform.position = targetRespawnBullet.position;
        bullet.GetComponent<Bullet>().direction = direction;
    }
}
