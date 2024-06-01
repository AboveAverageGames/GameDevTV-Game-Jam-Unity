using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //NOTE TO SELF will need 5 COMPLETE LAYERS of DAM to complete a WAVE

    //This is the logs the player has placed so far
    public int logsPlacedThisLayer;
    private int layersCompletedThisWave = 0;

    private bool waveCompleted;

    public int additionalLogsSpawned;
    public int currentWave;

    private int totalLogsNededToCompleteDamLayer = 10;


    // Start is called before the first frame update
    void Start()
    {
        //On start resets wave to 1
       currentWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player has completed one layer of the dam
        if (logsPlacedThisLayer == totalLogsNededToCompleteDamLayer)
        {
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
            totalLogsNededToCompleteDamLayer = totalLogsNededToCompleteDamLayer + 2;

            //Resets Wave Completed to false
            waveCompleted = false;

            Debug.Log("Total Logs needed to complete the layer is now" +  totalLogsNededToCompleteDamLayer);
        }
    } 
}
