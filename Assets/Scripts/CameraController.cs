using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isKeepAndFocus = false;
    public float horizontalSpeed = 14;
    public float verticalSpeed = 14;
    public float scrollSpeed = 20;
    public bool isMove = false;
    private GameObject target;
    public float offsetHeight = 3.5f;
    public float speed = 2.0f;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        Vector3 posTarget =  target.transform.position;
        Vector3 position = transform.position;
        position.y = Mathf.Lerp(position.y, posTarget.y + offsetHeight, interpolation); 
        position.x = Mathf.Lerp(position.x, posTarget.x,interpolation);
        transform.position = position;
    }
}
