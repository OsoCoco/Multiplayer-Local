using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public List<Material> differentColors;
    public Transform[] spawnPoints;
    public int playerID;
    // Start is called before the first frame update
    public void OnSpawnPlayer(PlayerInput playerInput)
    {
        Material rMat = differentColors[Random.Range(0, differentColors.Count)];
        playerInput.gameObject.transform.position = spawnPoints[playerID].position;
        playerInput.gameObject.GetComponent<Tank>().ChangeColor(rMat);
        playerInput.gameObject.GetComponent<Tank>().spawnPoint = spawnPoints[playerID];
        differentColors.Remove(rMat);
        playerID++;
        Debug.Log("Se agrego al jugador: " + playerID);
    }
}
