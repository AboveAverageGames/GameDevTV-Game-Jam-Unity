using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //NOTE TO SELF will need 5 COMPLETE LAYERS of DAM to complete a WAVE

    public GameObject activeLogsInScene;
    public GameObject activeLogInPlayersMouth;

    //This is the logs the player has placed in the dam so far
    public int logsPlacedThisLayer;
    private int layersCompletedThisWave = 0;

    public bool waveCompleted;

    //Log spawning Stuffs
    public int additionalLogsAllowedToBeSpawned;
    public int logsSpawnedThisLayer;
    public bool canAnyMoreLogsBeSpawned;


    public int currentWave;

    //Game starts at 10 logs for a layer
    public int totalLogsNeededToCompleteDamLayer = 10;


    // Start is called before the first frame update
    void Start()
    {
        canAnyMoreLogsBeSpawned = true;

        //On start resets wave to 1
        currentWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player has completed one layer of the dam
        if (logsPlacedThisLayer >= totalLogsNeededToCompleteDamLayer)
        {
            //In case spawn limit is reached but they have one in their mouth 
            canAnyMoreLogsBeSpawned = true;
            logsSpawnedThisLayer = 0;
            //Adds one to layers completed this wave
            layersCompletedThisWave++;
            //Resets Logs placed THIS layer to 0
            logsPlacedThisLayer = 0;

            Debug.Log("Layer Complete");
        }

        //Checks if ALL Layers has been placed there for completing a wave
        if (layersCompletedThisWave == 5)
        {
            //Completed a wave
            waveCompleted = true;

            //Resets the layers completed this wave
            layersCompletedThisWave = 0;

            Debug.Log("Wave Complete");
        }

        if (waveCompleted)
        {
            //Each wave adds 2 more logs needed to complete a layer of the dam
            totalLogsNeededToCompleteDamLayer = totalLogsNeededToCompleteDamLayer + 2;

            //Resets Wave Completed to false
            waveCompleted = false;

            Debug.Log("Total Logs needed to complete the layer is now" +  totalLogsNeededToCompleteDamLayer);
        }



        // -------------------------------------------- LOG SPAWN STUFF BELOW  -----------------------------------------


        //Checks if spawner has spawned Max amount of logs allowed for player to complete this layer of the dam
        //If not then they have lost the game
            if ((logsSpawnedThisLayer - additionalLogsAllowedToBeSpawned) == totalLogsNeededToCompleteDamLayer)
            {
                //Disables spawner
                canAnyMoreLogsBeSpawned = false;

                //Checks active logs in scene while spawn is done
                activeLogsInScene = GameObject.FindGameObjectWithTag("Log");

                //Checks if there is a log being held by the player also
                activeLogInPlayersMouth = GameObject.FindGameObjectWithTag("HeldLog");
            }

            //Checks if log spawn limit is hit AND There Is no Logs in scene
            if (!canAnyMoreLogsBeSpawned && activeLogsInScene == null && activeLogInPlayersMouth == null)
            {
                Debug.Log("GAME OVER YOU GOT NO LOGS LEFT TO SPAWN OR ON THE SCREEN. NO OPTIONS AND NO DAM FAMILY");
            }
 

       
    } 
}
