using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMGR : MonoBehaviour
{
    public GameObject display = null;
    public Material failImage = null;
    public OVRPlayerController playerController = null;

    private int HP = 100;
    private bool isFinished = false;
    
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public int getHP()
    {
        return HP;
    }
    
    public void causeDamage(int damage)
    {
        if (!isFinished)
        {
            HP -= damage;
            Debug.Log(damage + " 데미지");
            if (HP <= 0)
            {
                showDisplay(false, failImage);
            }
        }
    }

    public void showDisplay(bool success, Material image)
    {
        if(success)
        {
            display.GetComponent<MeshRenderer>().material = image;
            display.SetActive(true);
        }
        else
        {
            playerController.EnableLinearMovement = false;
            display.GetComponent<MeshRenderer>().material = image;
            display.SetActive(true);
        }
    }
}
