using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour
{


  public void MuteToggle(bool muted)
    {
        if(muted)
        {
            AudioListener.volume = 0.0f;
        }

        else
        {
            AudioListener.volume = 1.0f;
        }
    }



}
