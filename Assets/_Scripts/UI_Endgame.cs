
using UnityEngine;
using UnityEngine.UI;
public class UI_Endgame : MonoBehaviour
{
   public Text message;
   public Text score;
   public Text highscore;
   public GameObject continueButton;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas > 0)
        {
            message.text = "MISSION PASSED";
            continueButton.SetActive(true);
        }
        else
        {
            message.text = "WASTED";
            continueButton.SetActive(false);
        }
        score.text = $"SCORE: {gm.pontos}";
        highscore.text = $"HIGHSCORE: {gm.LoadHighscore()}";
    }

    public void Voltar()
    {
        gm.Reset();
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Continuar()
    {
        gm.newGame = true;
        gm.ChangeState(GameManager.GameState.GAME);
    }
}