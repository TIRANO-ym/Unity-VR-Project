using UnityEngine;

public class FireMGR : MonoBehaviour
{
    public Material image;                  // 불을 모두 껐을 경우 전달할 이미지

    private Transform[] firePoints;         // 불이 출현할 위치
    private GameObject fire;                // 불 객체를 할당할 변수. (Tag = Fire)
    private AudioSource[] sounds;

    private int fireCount = 0, maxFireCount = 4;

    public static FireMGR instance = null;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sounds = GameObject.Find("FireManager").GetComponentsInChildren<AudioSource>();
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
            // fireCount번째 불 >>> FireSpawnPoint의 index번째에 생성
            Instantiate(fire, firePoints[index].position, firePoints[index].rotation);
            used[fireCount] = index;
            fireCount++;
        }
        
        Destroy(fire);
        Invoke("playAudio", 3);         // 게임 시작하고 3초 뒤 사이렌 발생
    }

    private void playAudio()
    {
        foreach(AudioSource audio in sounds)
            audio.Play();
    }
    
    public void reduceFire()
    {
        fireCount--;
        // 모든 화재 진압 시
        if(fireCount <= 0)
        {
            foreach (AudioSource audio in sounds)
                audio.Stop();

            GameObject.Find("PlayerManager").GetComponent<PlayerMGR>().showDisplay(true, image);
        }
    }
}
