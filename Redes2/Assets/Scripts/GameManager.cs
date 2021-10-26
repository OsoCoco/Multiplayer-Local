using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public List<Tank> tanks;
    List<int> scores;
    public int playerID;
    // Start is called before the first frame update
    public void OnSpawnPlayer(PlayerInput playerInput)
    {
        Debug.Log("Joined");

        GameObject go = playerInput.gameObject;
        go.transform.position = spawnPoints[playerID].position;
        
        go.GetComponent<Tank>().spawnPoint = spawnPoints[playerID];
        tanks.Add(go.GetComponent<Tank>());
        
        playerID++;
        go.GetComponent<Tank>().ID = playerID;
        Debug.Log("Se agrego al jugador: " + playerID);
    }

    void CheckWinner()
    {
        for(int i = 0;i < tanks.Count;i++)
        {
            scores.Add(tanks[i].score);
        }

        int winnerScore = scores.Max();

        int winnerID = scores.IndexOf(winnerScore);
        
    }
}
