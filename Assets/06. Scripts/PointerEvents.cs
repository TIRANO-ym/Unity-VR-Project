using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    //[SerializeField] private Color normalColor = Color.white;
    //[SerializeField] private Color enterColor = Color.white;
    //[SerializeField] private Color downColor = Color.white;
    public Material normal = null;
    public Material enter = null;
    public Material down = null;

    [SerializeField] private UnityEvent onClick = new UnityEvent();

    public MeshRenderer meshRenderer = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material = enter;
        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = normal;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        meshRenderer.material = down;
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        meshRenderer.material = enter;
        print("Up");
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //onClick.Invoke();
        print(gameObject.name + "Click");
        if(gameObject.name == "Start")
            SceneManager.LoadScene("HanbatUniversity");
        else if (gameObject.name == "Exit")
            Application.Quit();
        else if(gameObject.name == "Restart")
            SceneManager.LoadScene("Home");
    }
}
