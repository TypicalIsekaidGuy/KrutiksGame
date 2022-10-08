using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Win"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if(collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
