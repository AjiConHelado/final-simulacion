using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Timeline;

public class misilesSpawner : MonoBehaviour
{
    private Queue<collisionMisil> pool;
    [SerializeField]
    private GameObject misil;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int initialSize, incrementAmount;
    private float timer;


    void Awake()
    {
        pool = new Queue<collisionMisil>();
       
    }
    void Start()
    {
        AddInstances(initialSize, pool, misil);
    }

    // Update is called once per frame
    void Update()
    {
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                placemisil(Spawnmisil());
                timer = spawnTimer;
            }
        }
    }


    GameObject Spawnmisil()
    {

        return Allocate(pool, misil);
    }

    

     void AddInstances(int amount, Queue<collisionMisil> instances, GameObject prefab)
    {
        for (int i = 0; i < amount; i++)
        {
            collisionMisil obj = Instantiate(prefab, gameObject.transform).GetComponent<collisionMisil>();
            
            obj.Spawner = this;
            obj.gameObject.SetActive(false);
            //obj.haciaPlayer.player = posicion;
            instances.Enqueue(obj);
        }
    }

     GameObject Allocate(Queue<collisionMisil> instances, GameObject prefab)
    {
        GameObject instance;

        if (instances.Count == 0)
        {
            AddInstances(incrementAmount, instances, prefab);
            return Allocate(instances, prefab);
        }

        instance = instances.Dequeue().gameObject;
        instance.SetActive(true);

        

        return instance;
    }

    public void Return(collisionMisil instance)
    {
        Queue<collisionMisil> instances = new Queue<collisionMisil>();

        
                instances = pool;
         
        

        instances.Enqueue(instance);
        instance.gameObject.SetActive(false);
    }

     Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5 ? -1 : 1;
         if (Random.value > 0.5f)
         {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
            }
         else
         {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
         }

        position.z = 0;

        return position;
    }

void placemisil(GameObject misil)
{
    Vector3 position = GenerateRandomPosition();

    

    misil.transform.position = position;
}

}

