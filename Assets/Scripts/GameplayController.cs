using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance;
    [SerializeField] private GameObject animalPrefab;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject ingameUI;

    public GameConfig Config;

    private void Start() {
        Instance = this;
    }

    public void StartSimulation(){
        ground.SetActive(true);
        ground.transform.localScale = new Vector3(Config.MapSize, 0.1f, Config.MapSize);

        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 direction = cameraPosition - Vector3.zero;
        Camera.main.transform.position = direction.normalized * Config.MapSize;

        for(int i = 0; i < Config.AnimalCount; i++){
            CreatePair();
        }

        menu.SetActive(false);
        ingameUI.SetActive(true);
    }

    private void CreatePair(){
        GameObject animalObject = Instantiate(animalPrefab);
        Animal animal = animalObject.GetComponent<Animal>();
        animalObject.transform.position = animal.FindRandomPosition();

        animal.Food = Instantiate(foodPrefab).GetComponent<Food>();
        animal.Food.animal = animal;
        animal.Food.CreateFood();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
