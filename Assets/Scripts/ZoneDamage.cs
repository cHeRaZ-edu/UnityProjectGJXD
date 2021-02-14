using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target = null;
    // Update is called once per frame
    void Update() {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            target = null;
        }
    }
}
