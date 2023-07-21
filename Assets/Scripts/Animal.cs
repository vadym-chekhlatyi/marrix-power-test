using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [HideInInspector] public Food Food;
    private Vector3 direction;
    private GameConfig config;
    private Rigidbody rigidBody;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        config = GameplayController.Instance.Config;
    }

    private void FixedUpdate()
    {
        if(Food.gameObject.activeInHierarchy){
            direction = Food.transform.position - transform.position;
            transform.Translate(direction.normalized * config.Speed * Time.deltaTime);
        }else{
            Food.CreateFood();
        }
    }
    
    public Vector3 FindRandomPosition()
    {
        int mapSize = GameplayController.Instance.Config.MapSize / 2;
        float x = UnityEngine.Random.Range(-mapSize, mapSize);
        float z = UnityEngine.Random.Range(-mapSize, mapSize);
        return new Vector3(x, 0f, z);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == Food.gameObject){
            Destroy(Instantiate(Food.particles, transform.position, Quaternion.identity), 1f);
            Food.gameObject.SetActive(false);
        }
    }
}
