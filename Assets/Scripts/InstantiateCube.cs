using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;

public class InstantiateCube : MonoBehaviour
{
    public Realtime realtime;
    public Transform spawnPosition;

    private void SpawnCube(Realtime realtime)
    {
        //Instantiate the CubePlayer for this client once we've successfully connected to the room
        Realtime.Instantiate("NormcoreGrabbable", 
            position: spawnPosition.position, 
            rotation: Quaternion.identity,
            ownedByClient: false, 
            preventOwnershipTakeover: false, 
            useInstance: realtime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            SpawnCube(realtime);
        }
    }
}
