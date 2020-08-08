using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    public Transform playerTr = null;
    public PlayerMGR playerMGR = null;
    public Material image = null;

    private Transform pointerTr;
    private float dist, exitDist;

    void Start()
    {
        pointerTr = this.gameObject.transform;
        exitDist = 1f;
    }


    void Update()
    {
        // @@@@@@@@@@탈출 성공 사운드 재생
        //new WaitForSeconds(0.5f);

        dist = Vector3.Distance(playerTr.position, pointerTr.position);

        if (dist <= exitDist)
        {
            Destroy(pointerTr.gameObject);
            playerMGR.showDisplay(true, image);
        }
    }
}