using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct StageRound
{
    public List<KeyValuePair<Enemy,float>> enemyList;
    public float nextRoundCoolTime;
    
    public StageRound(List<KeyValuePair<Enemy,float>> el, float nrct = 20)
    {
        enemyList = el;
        nextRoundCoolTime = nrct;
    }
    

}


public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab;

    public float coolTime = 0.0f;
    public float deltatime = 0.0f;
    MonsterCollection monsterCollection;


    public int gold = 1000;
    public int life = 3;

    private bool isWait = true;
    private bool isEnd = false;

    public float acceleration = 1;

    public Button startButton;


    List<StageRound> rounds;

    // Start is called before the first frame update
    void Start()
    {
        coolTime = 9999999;
        startButton.gameObject.SetActive(true);
        monsterCollection = GameObject.FindGameObjectWithTag("MonsterCollection").GetComponent<MonsterCollection>();
        rounds = new List<StageRound>();

        MakeStage();
    }

    // Update is called once per frame
    void Update()
    {
        deltatime += Time.deltaTime;
        if (deltatime > coolTime)
        {
            if (rounds.Count > 0)
            {
                if (rounds[0].enemyList.Count > 0)
                {
                    startButton.gameObject.SetActive(false);
                    Instantiate(rounds[0].enemyList[0].Key);
                    deltatime = 0;
                    coolTime = rounds[0].enemyList[0].Value;
                    rounds[0].enemyList.RemoveAt(0);

                }

                else if (rounds[0].enemyList.Count <= 0)
                {

                    coolTime = rounds[0].nextRoundCoolTime;
                    rounds.RemoveAt(0);

                    if(rounds.Count <= 0)
                    {
                        coolTime = 9999999;
                        print("场");
                        isEnd = true;
                        isWait = false;
                        coolTime = 0;
                        startButton.gameObject.SetActive(false);
                    }
                    WaitForNextRound();
                    
                }
            }
            else if (rounds.Count <= 0)
            {
                coolTime = 0;
                print("场");
                isEnd = true;
                isWait = false;
                coolTime = 0;
                startButton.gameObject.SetActive(false);
            }
        }

        if (isEnd)
        {
            var a = GameObject.FindGameObjectsWithTag("Monster");
            if (a.Length == 0)
            {
                print("场车促");
                SceneManager.LoadScene("Stage Clears");
            }
        }


        if(life <= 0)
        {
            SceneManager.LoadScene("StageSelect");
        }
    }



    void MakeStage()
    {
        //round1
        List<KeyValuePair<Enemy, float>> round1 = new List<KeyValuePair<Enemy, float>>();
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.blueVirus, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenVirus, 0.7f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.1f));

        rounds.Add(new StageRound(round1, 30));
        //round2
        List<KeyValuePair<Enemy, float>> round2 = new List<KeyValuePair<Enemy, float>>();
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.1f));

        rounds.Add(new StageRound(round2, 30));

        //round3
        List<KeyValuePair<Enemy, float>> round3 = new List<KeyValuePair<Enemy, float>>();
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.1f));

        rounds.Add(new StageRound(round3, 100));

        
    }

    public void WaitForNextRound()
    {
        isWait = true;
        startButton.gameObject.SetActive(true);
    }

    public void StartNextRound()
    {
        if(isEnd == true)
        {
            print("咯扁八荤吝");
            var a = GameObject.FindGameObjectsWithTag("Monster");
            if (a.Length == 0)
            {
                print("场车促");
                SceneManager.LoadScene("Stage Clear");
            }

            return;
        }

        coolTime = 0;
        startButton.gameObject.SetActive(false);
        isWait = false;
    }
}
