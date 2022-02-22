using UnityEngine;
using UnityEngine.UI;

public class UI_Start : MonoBehaviour
{

  GameManager gm;

  private void OnEnable()
  {
    gm = GameManager.GetInstance();
  }
 
  public void Comecar()
  {
    gm.Reset();
    gm.ChangeState(GameManager.GameState.GAME);
  }
}