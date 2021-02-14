using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float moveSpeedMax = 0.2f;
    public float gravity = 9.4f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject groupBox;
    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        GameObject _groupBox = GameObject.Instantiate(groupBox,GameObject.FindGameObjectWithTag("UIGame").transform);
        _groupBox.AddComponent<CharacterInfo>();
        CharacterInfo ci = _groupBox.GetComponent<CharacterInfo>();
        ci.target = gameObject.transform.GetChild(0).gameObject;
        ci.isStart = true;
    }

    // Update is called once per frame
    void Update() {
        if(!GameManager.Instance.GetIsPauseGame()) {

            float speed = Input.GetKey(KeyCode.LeftShift) ? moveSpeedMax : moveSpeed;
            if (controller.isGrounded)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");
                moveDirection = new Vector3(moveX, 0, moveZ);
                moveDirection *= speed;
            }
            moveDirection.y -= gravity;
            controller.Move(moveDirection);
        }
    }
}
