using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class ObstaclesForSol : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;
    public Transform playerControls;
    [SerializeField]
    private Transform spawnPoint;
    private PlayerControls.PLAYER_CHARACTERS character_to_use = PlayerControls.PLAYER_CHARACTERS.Sol;

    private void Start()
    {

        Debug.Log(playerControls.position.ToString());
        Debug.Log(spawnPoint.position.ToString());
    }
    private void Update()
    {
        Debug.Log(PlayerControls.current_player_character.ToString());
        Debug.Log(character_to_use.ToString());
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && character_to_use.Equals(PlayerControls.current_player_character))
        {
            gameManager.ShowButton();
            gameManager.SetObstacleSol(this);
        }
        else if (!character_to_use.Equals(PlayerControls.current_player_character))
            gameManager.HideButton();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameManager.HideButton();
    }
    public void BreakObstacle()
    {
        StartCoroutine(LadderAnimation());
/*        playerControls.gameObject.GetComponent<PlayerControls>().ChangeLocation(spawnPoint);
*/
    }
    IEnumerator LadderAnimation()
    {
        playerControls.gameObject.GetComponent<CharacterController>().enabled = false;
        while (playerControls.position.y < spawnPoint.position.y)
        {
            playerControls.position += new Vector3(0,0.05f,0);
            yield return new WaitForSeconds(0.01f);
        }
        while (playerControls.position.z < spawnPoint.position.z)
        {
            playerControls.position += new Vector3(0, 0, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        playerControls.gameObject.GetComponent<CharacterController>().enabled = true;
        gameManager.HideButton();
        yield return null;
    }
}
