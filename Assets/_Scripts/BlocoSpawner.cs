using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Bloco;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();

        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir()
    {
        if(gm.gameState == GameManager.GameState.GAME)
        {
            foreach(Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            for(int i=0; i<1; i++)
            {
                for(int j=0; j<1; j++)
                {
                    Vector3 posicao = new Vector3(-9 + 1.55f*i, 4 - 0.55f*j);
                    Instantiate(Bloco, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {
        if(transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            if(gm.pontos > gm.highscore)
            {
                gm.highscore = gm.pontos;
            }
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    
}
