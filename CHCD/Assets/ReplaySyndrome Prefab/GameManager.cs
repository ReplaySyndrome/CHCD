using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float deltatime = 0.0f;
    MonsterCollection monsterCollection;

    private bool isWait = false;


    List<StageRound> rounds;

    // Start is called before the first frame update
    void Start()
    {

        monsterCollection = GameObject.FindGameObjectWithTag("MonsterCollection").GetComponent<MonsterCollection>();
        rounds = new List<StageRound>();

        MakeStage();
    }

    // Update is called once per frame
    void Update()
    {
        deltatime += Time.deltaTime;

        if(deltatime > coolTime)
        {
            if (rounds.Count > 0)
            {
                if (rounds[0].enemyList.Count > 0)
                {
                    Instantiate(rounds[0].enemyList[0].Key);
                    deltatime = 0;
                    coolTime = rounds[0].enemyList[0].Value;
                    rounds[0].enemyList.RemoveAt(0);

                    print(rounds[0].enemyList.Count.ToString() + "남았다");
                }

                else if (rounds[0].enemyList.Count <= 0)
                {
                    rounds.RemoveAt(0);
                    print("라운드끝");
                }
            }
            else if (rounds.Count <= 0)
            {
                coolTime = 9999999;
                print("게임끝");
            }
        }
    }



    void MakeStage()
    {
        //round1
        List<KeyValuePair<Enemy, float>> round1 = new List<KeyValuePair<Enemy, float>>();
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round1.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 7));

        rounds.Add(new StageRound(round1, 15));
        //round2
        List<KeyValuePair<Enemy, float>> round2 = new List<KeyValuePair<Enemy, float>>();
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round2.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 7));

        rounds.Add(new StageRound(round2, 10));

        //round3
        List<KeyValuePair<Enemy, float>> round3 = new List<KeyValuePair<Enemy, float>>();
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 3));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 5));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 4));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 2));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 1));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 0.5f));
        round3.Add(new KeyValuePair<Enemy, float>(monsterCollection.greenMonster, 7));

        rounds.Add(new StageRound(round3, 100));

        
    }
}
