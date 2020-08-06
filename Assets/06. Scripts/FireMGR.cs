using UnityEngine;

public class FireMGR : MonoBehaviour
{
    public Transform[] firePoints; //불이 출현할 위치
    public GameObject fire; // 불 객체를 할당할 변수.

    int fireCount = 0, maxFireCount = 4;

    public static FireMGR instance = null;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        firePoints = GameObject.Find("FireSpawnPoint").GetComponentsInChildren<Transform>();

        fire = GameObject.FindGameObjectWithTag("Fire");
        fire.SetActive(true);

        int[] used = new int[maxFireCount];

        while (fireCount < maxFireCount)
        {
            int index = 0;
            bool flag = true;

            while (flag)
            {
                index = Random.Range(0, firePoints.Length-1);

                for (int i = 0; i < used.Length; i++)
                {
                    if (used[i] == index)
                    {
                        flag = true;
                        break;
                    }
                    else
                        flag = false;
                }
            }

            Instantiate(fire, firePoints[index].position, firePoints[index].rotation);
            used[fireCount] = index;
            Debug.Log(fireCount + "번째 불>>> FireSpawnPoint의 index" + index + "번째에 생성");
            fireCount++;
        }

        Destroy(fire);

        
    }
}
