using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerControls player;
    public ObstaclesForRay obstaclesForRay;
    public ObstaclesForSol obstaclesForSol;
    public Button ability_button;
    public void ShowButton()
    {
        ability_button.interactable = true;
    } 
    public void HideButton()
    {
        ability_button.interactable = false;
    }
    public void SetObstacleRay(ObstaclesForRay obs)
    {
        obstaclesForRay = obs;
    }
    public void SetObstacleSol(ObstaclesForSol obs)
    {
        obstaclesForSol = obs;
    }
}
