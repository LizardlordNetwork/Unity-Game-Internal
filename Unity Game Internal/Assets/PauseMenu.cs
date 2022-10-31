using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public static bool GameisPaused = false;

    // Update is called once per frame
    void Update()
    {
        //If the space key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause the game.
             GameisPaused = true;
        }

        if (GameisPaused == true)
        {
            //Enable Pause Menu.
        }
    }

}
