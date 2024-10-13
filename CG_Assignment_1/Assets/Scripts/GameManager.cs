using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    public int points;

    [SerializeField] private float endTime;


    public int Points {
        get {
            return points;
        }
        set {
            points = value;
        }
    }

   
    private void Update()
    {
        pointText.text = points.ToString();
    }

    private IEnumerator EndDelay()
    {
        yield return new WaitForSeconds (endTime);
    }
    
    public void EndGame()
    {
        EndDelay();
        SceneManager.LoadScene(1);
    }
}
