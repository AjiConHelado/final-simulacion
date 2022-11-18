using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum tipo
{
    horizontal,vertical
}
public class osilacion : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float period = 1;
    [SerializeField] private tipo orientacion;
    [SerializeField]
    [Range(0, 10)]
    private float amplitude = 2;
    
   
    void Update()
    {
        // Simple harmonic movement on x component
        float factor = Time.time / period;
        
        float x =  amplitude * Mathf.Sin(2 * Mathf.PI * factor);

        // Update the position
        if(orientacion==tipo.horizontal)
        {
            transform.localPosition = new Vector3(x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.position.x, x, transform.position.z);
        }
        //transform.position.Draw(Color.yellow);
    }
}
