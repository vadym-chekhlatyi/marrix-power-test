using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector] public Animal animal;
    public ParticleSystem particles;

    public void CreateFood(){
        transform.position = FindRandomFoodPosition();
        gameObject.SetActive(true);
    }

    public Vector3 FindRandomFoodPosition()
    {
        float speed = GameplayController.Instance.Config.Speed;
        int maxRange = GameplayController.Instance.Config.MaxRange;
        int mapSize = GameplayController.Instance.Config.MapSize / 2;
        Transform animalTransform = animal.transform; 

        float x = mapSize;
        while(x >= mapSize || x <= -mapSize){
            x = UnityEngine.Random.Range(animalTransform.position.x - maxRange, animalTransform.position.x + maxRange);
        }

        float z = mapSize;
        while(z >= mapSize || z <= -mapSize){
            z = UnityEngine.Random.Range(animalTransform.position.z - maxRange, animalTransform.position.z + maxRange);
        }

        return new Vector3(x, 0f, z);
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Food>() != null){
            transform.position = FindRandomFoodPosition();
        }
    }
}