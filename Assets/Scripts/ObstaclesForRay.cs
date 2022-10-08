using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesForRay : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody[] parts = new Rigidbody[6];
    private PlayerControls.PLAYER_CHARACTERS character_to_use = PlayerControls.PLAYER_CHARACTERS.Ray;
    void Start()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && character_to_use.Equals(PlayerControls.current_player_character))
        {
            gameManager.ShowButton();
            gameManager.SetObstacleRay(this);
        }
        else if (other.gameObject.CompareTag("Player") && !character_to_use.Equals(PlayerControls.current_player_character))
            gameManager.HideButton();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameManager.HideButton();
    }
    public void BreakObstacle()
    {
        foreach (var part in parts)
        {
            part.isKinematic = false;
        }
    }

}
