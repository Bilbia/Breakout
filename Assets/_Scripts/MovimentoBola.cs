using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1,15)]
    public float velocidade = 5.0f;

    private Vector3 direcao;

    private bool launchBall = false;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;

        launchBall = WaitToLaunchBall(launchBall);

        if(launchBall)
        {
            
            transform.position += direcao*Time.deltaTime*velocidade;

            Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

            if(posicaoViewport.x < 0 || posicaoViewport.x > 1)
            {
                direcao = new Vector3(-direcao.x, direcao.y);
            }

            if(posicaoViewport.y > 1)
            {
                direcao = new Vector3(direcao.x, -direcao.y);
            }

            if(posicaoViewport.y < 0)
            {
                Reset();
            }

            Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
        }
    }

    private void Reset()
    {
        if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        
        launchBall = false;
        gm.vidas--;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Tijolo"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }

    private bool WaitToLaunchBall(bool launchBall)
    {
        if(!launchBall){
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = playerPosition + new Vector3(0, 0.5f, 0);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            launchBall = true;

            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(2.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }

        return launchBall;
    }
}
