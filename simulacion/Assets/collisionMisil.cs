using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionMisil : MonoBehaviour
{
    [HideInInspector] public misilesSpawner Spawner;
    [SerializeField]private GameObject señal;
   public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("salchicha");
       
        //player c = collision.GetComponent<player>();
      
        if (collision.tag=="misil")
        {
          
            Spawner.Return(this);
            
        }
    }
}
