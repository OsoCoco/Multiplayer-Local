using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public int playerID;
    // Start is called before the first frame update
    public void OnSpawnPlayer(PlayerInput playerInput)
    {
        playerInput.gameObject.transform.position = spawnPoints[playerID].position;
        playerID++;
        Debug.Log("Se agrego al jugador: " + playerID);
    }
}
