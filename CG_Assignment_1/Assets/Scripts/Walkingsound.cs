using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Walkingsound : MonoBehaviour
{
   public AudioSource walking;

   void Update()
   {
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
    {
        walking.enabled = true;
    }
    else walking.enabled = false;
   }
}
