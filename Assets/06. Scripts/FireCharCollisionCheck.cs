using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharCollisionCheck : MonoBehaviour
{
    public PlayerMGR playerMGR = null;
    public Transform playerTr = null;

    private Transform fireTr = null;
    private int fireDamage = 30;
    private float current_dist, damage_dist;

    void Start()
    {
        fireTr = this.gameObject.transform;
        damage_dist = 2f;
    }

    void Update()
    {
        // @@@@@@@@@@불에 타는 소리 재생
        current_dist = Vector3.Distance(playerTr.position, fireTr.position);

        if (current_dist <= damage_dist)        // 불에 가까워지면
        {
            if (playerMGR.getHP() > 0)
            {
                Debug.Log("화재와 캐릭터 충돌");
                playerMGR.causeDamage(fireDamage);
            }
        }
    }

    public void reductionDamageDist()
    {
        damage_dist -= 0.2f;
    }
}
