using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerScore))]
public class PlayerWinGame : MonoBehaviour
{
    public void Win()
    {
        Debug.Log("Venceu!");
        GetComponent<PlayerScore>().DumpScore();
    }
}
