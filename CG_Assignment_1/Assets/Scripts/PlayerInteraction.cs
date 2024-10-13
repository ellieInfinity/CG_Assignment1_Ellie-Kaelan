using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] spotLights;

    private GameManager gameManager;
    public bool isInSafeZone;

    public static int points;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Points"))
        {
            gameManager.Points++;
            PointsStorage.totalScore++;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Safe"))
        {
            isInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Safe"))
        {
            isInSafeZone = false;
            Debug.Log("left trigger");
        }
    }

    void Update()
    {
        foreach(GameObject light in spotLights)
        {
            
            if(light.activeInHierarchy)
            {
                StartCoroutine(ForgivenessTime());
                return;
            }
            else continue;
        }
        Debug.Log(PointsStorage.totalScore);
    }

    private IEnumerator ForgivenessTime()
    {
        yield return new WaitForSeconds (0.1f);
        if(isInSafeZone)
            {
                Debug.Log("safe");
            }
            else 
            {
                gameManager.EndGame();
            }
    }

}
