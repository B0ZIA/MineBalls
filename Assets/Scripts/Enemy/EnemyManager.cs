using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject emptyShapePrefab;
    [SerializeField]
    private Transform enemyCointerner;


    void Awake()
    {
        if(Instance == null)
            Instance = this;

        SpawnSeries();
    }

    public void SpawnSeries()
    {
        for (int i = 0; i < 6; i++)
        {
            var hp = CalculateHp();
            GameObject prefab = null;

            if (Spawn())
            {
                prefab = Instantiate(enemyPrefab, enemyCointerner);
                prefab.GetComponent<Enemy>().Init(hp, true);
            }
            else
            {
                prefab = Instantiate(emptyShapePrefab, enemyCointerner);
                prefab.AddComponent<Enemy>().Init(hp, false);
            }

            if (prefab != null)
                prefab.transform.SetAsFirstSibling();
        }
    }

    private bool Spawn()
    {
        return Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
    }

    private int CalculateHp()
    {
        int currentLvl = PlayerLevel.Instance.GetLevel();
        var enemyHp = UnityEngine.Random.Range(currentLvl / 2, currentLvl * 2);

        return enemyHp;
    }
}
