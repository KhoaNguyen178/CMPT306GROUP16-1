using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Vector3 vMovement;
    [SerializeField] public float speed = 3.0f;
    Animate animate;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        vMovement = new Vector3();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        vMovement.x = Input.GetAxisRaw("Horizontal");
        vMovement.y = Input.GetAxisRaw("Vertical");
        animate.horizontal = vMovement.x;
        vMovement *= speed;
        rBody.velocity = vMovement;
    }
}
