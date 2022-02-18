
using UnityEngine;
using UnityEngine.UI;
public class UI_Endgame : MonoBehaviour
{
   public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas > 0)
        {
            message.text = "MISSION PASSED";
        }
        else
        {
            message.text = "WASTED";
        }
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}