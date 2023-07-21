using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameConfig : MonoBehaviour
{
    public int MaxRange = 5;
    public int MapSize = 2;
    public int AnimalCount;
    public float Speed = 1f;

    public Slider MapSizeSlider;
    [SerializeField] private TextMeshProUGUI mapSizeText;

    public Slider AnimalCountSlider;
    [SerializeField] private TextMeshProUGUI animalCountText;

    public Slider SpeedSlider;
    [SerializeField] private TextMeshProUGUI speedText;

    private void Start() {
        mapSizeText.text = MapSize.ToString();
        animalCountText.text = AnimalCount.ToString();
        speedText.text = Speed.ToString();
    }

    public void UpdateMapSize(){
        MapSize = (int)MapSizeSlider.value;
        mapSizeText.text = MapSize.ToString();
        AnimalCountSlider.maxValue = MapSize;
    }
    
    public void UpdateAnimalCount(){
        AnimalCount = (int)AnimalCountSlider.value;
        animalCountText.text = AnimalCount.ToString();
    }

    public void UpdateSpeed(){
        Speed = (int)SpeedSlider.value;
        speedText.text = Speed.ToString();
    }
}
