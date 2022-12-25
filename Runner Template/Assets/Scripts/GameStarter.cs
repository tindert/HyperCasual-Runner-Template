using UnityEngine;
using UnityEngine.EventSystems;
public class GameStarter : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.instance.StartGame();
        gameObject.SetActive(false);
    }
}
