using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MiniGameCollection.Games2024.Team12
{
    public class Restart : MonoBehaviour
    {
        TextMeshPro tmp;
        bool player1Ready = false;
        bool player2Ready = false;

        public void Update()
        {

            if (Input.GetKey(KeyCode.E)) 
            {
                player1Ready = true;
                tmp.gameObject.SetActive(true);

            }

            if (Input.GetKey(KeyCode.L))
            {
                player2Ready = true;

                tmp.gameObject.SetActive(true);
            }


            if (player1Ready && player2Ready)
            {
                newGame();
            }
        }



        public void newGame()
        {
            SceneManager.LoadScene("2024-team12-game");
        }


    }
}
