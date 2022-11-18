using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haciaPlayer : MonoBehaviour
{
    private enum Modo
    {
        Constant,
        Acceleration
    }

    [SerializeField] private Modo movementMode;
    [SerializeField] private float speed;
    private Vector3 acceleration;
    private Vector3 velocity;
    [SerializeField] private Camera camera;
    [SerializeField] Transform player;
   
    [SerializeField] private float maxvel;
    private void Update()
    {
        UpdateMovementVectors();
        if (velocity.magnitude > maxvel)
        {
            velocity = velocity*0.5f;
        }
        else
        {
            velocity += acceleration * Time.deltaTime;
        }
        transform.position += velocity * Time.deltaTime;

        //RotateZ((Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f)/2);
    }

    private void UpdateMovementVectors()
    {
        if (movementMode == Modo.Constant)
        {
            velocity = player.position - transform.position;
           // velocity = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
            velocity.Normalize();
            velocity *= speed;
            acceleration *= 0;
        }
        else if (movementMode == Modo.Acceleration)
        {
            acceleration = player.position - transform.position;
           // acceleration = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
        }
    }

    
    private void RotateZ(float radian)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian * Mathf.Rad2Deg);
    }
}