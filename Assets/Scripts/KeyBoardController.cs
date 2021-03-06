﻿using UnityEngine;
using UnityEngine.UI;

public class KeyBoardController : MonoBehaviour
{
    [SerializeField] private float deltaSpeed = 0.1f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float pressCoef = 5;
    [SerializeField] private float rotationSpeed = 6;
    [SerializeField] private Text speedLabel;
    private Rigidbody rb;
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = minSpeed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed = Mathf.Min(maxSpeed, speed + deltaSpeed * pressCoef);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (speed > 0)
            {
                speed = Mathf.Max(minSpeed, speed - deltaSpeed * pressCoef);
            }
            else
            {
                speed = Mathf.Max(-maxSpeed, speed - deltaSpeed * pressCoef);
            }
        }
        else
        {
            if (speed >= 0)
            {
                speed = Mathf.Max(minSpeed, speed - deltaSpeed);
            }
            else
            {
                speed = Mathf.Min(maxSpeed, speed + deltaSpeed);
            }
        }

        string velovity = speed.ToString();

        if (velovity.Contains(",") || velovity.Contains(".")) //show not all digits, only 2 after dot
            velovity = string.Format("{0:0.00}", speed);

        speedLabel.text = velovity;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed; //sd inputs for rotation

        //corrert rotation if move back
        if (speed > 0)
            rb.AddTorque(new Vector3(0, rotation, 0));
        else if (speed < 0)
            rb.AddTorque(new Vector3(0, -rotation, 0));
    }
}