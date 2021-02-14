using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private SpriteRenderer sp;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        foreach (Transform child in transform) {
            if (child.tag == "SpriteKamikaze")
                sp = child.GetComponent<SpriteRenderer>();
        }
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        agent.destination = goal.position;
        Vector3 v = agent.velocity;
        if(v.x > 01) {
            sp.flipX = true;
        } else if(v.x < 0) {
            sp.flipX = false;
        }
    }
}
