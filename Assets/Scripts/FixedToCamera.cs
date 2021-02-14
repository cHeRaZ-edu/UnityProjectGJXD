using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedToCamera : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Awake() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(cam.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player")) {
            Debug.Log("Colision");
        }
    }
    private void Attack() {

    }
}
