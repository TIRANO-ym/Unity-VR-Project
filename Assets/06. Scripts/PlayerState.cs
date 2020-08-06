using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    int count = 0;

    void OnTriggerStay(Collider coll)
    {
       
        if (coll.transform.tag == "Player")
        {
            if (count >= 200)
            {
                print("사망하였습니다.");
            }
            else
                print(count++);
        }
    }

}
