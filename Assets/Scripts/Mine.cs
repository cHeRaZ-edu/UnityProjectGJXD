using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public bool isAcivateMine = false;
    public float timeMine = 1.5f;
    public bool isEventExplosion = true;
    public float damage = 33;
    public float timeDestory = 1.0f;
    private ZoneDamage zone;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            if (child.tag == "ZoneMine")
                zone = child.GetComponent<ZoneDamage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.GetIsPauseGame()) {
            if(isAcivateMine) {
                timeMine -= Time.deltaTime;
            }
            if(timeMine < 0) {
                if(isEventExplosion) {
                    isEventExplosion = false;
                    Explosion();
                } else {
                    timeDestory -= Time.deltaTime;
                    if(timeDestory < 0) {
                        DestroyImmediate(gameObject,true);
                    }
                }
            
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Explosion Time ...");
            isAcivateMine = true;
        }
    }
    private void Explosion() {
        Debug.Log("Explosion");
        if(zone.target) {
            PlayerController player = zone.target.GetComponent<PlayerController>();
            player.Damage(damage);
        }
    }
}
