using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float DISTANCE_UNIT = 1;

    [SerializeField]
    private GameObject enemyPrefab;

    private List<Field> enemyFields = new List<Field>()
    {
        new Field(0,8), new Field(1,8), new Field(2,8), new Field(3,8), new Field(4,8), new Field(5,8),
        new Field(0,7), new Field(1,7), new Field(2,7), new Field(3,7), new Field(4,7), new Field(5,7),
        new Field(0,6), new Field(1,6), new Field(2,6), new Field(3,6), new Field(4,6), new Field(5,6),
        new Field(0,5), new Field(1,5), new Field(2,5), new Field(3,5), new Field(4,5), new Field(5,5),
        new Field(0,4), new Field(1,4), new Field(2,4), new Field(3,4), new Field(4,4), new Field(5,4),
        new Field(0,3), new Field(1,3), new Field(2,3), new Field(3,3), new Field(4,3), new Field(5,3),
        new Field(0,2), new Field(1,2), new Field(2,2), new Field(3,2), new Field(4,2), new Field(5,2),
    };

    void Start()
    {
        SpawnSeries();
    }

    public void SpawnSeries()
    {
        for (int i = 0; i < enemyFields.Count; i++)
        {
            int currentLvl = PlayerLevel.Instance.GetLevel();
            var enemyHp = Random.Range(currentLvl/2, currentLvl * 2);

            var enemyCount = Random.Range(0, 2);

            if (enemyFields[i].pos.y == 8 && enemyCount == 1)
            {
                var enemy = Instantiate(enemyPrefab, enemyFields[i].pos, Quaternion.identity);
                enemy.GetComponent<Enemy>().Init(enemyHp);
                enemyFields[i].Enemy = enemy.GetComponent<Enemy>();
            }
        }
    }

    public void MoveSeries()
    {
        for (int i = enemyFields.Count-1; i >= 0; i--)
        {
            if (enemyFields[i].Enemy == null)
                continue;

            if (i + 6 < enemyFields.Count)
                enemyFields[i + 6].Enemy = enemyFields[i].Enemy;
            else
                break;

            if (enemyFields[i].pos.y == 8)
            {
                enemyFields[i].Enemy = null;
            }

            if (enemyFields[i + 6].Enemy != null && enemyFields[i + 6].pos.y == 2)
            {
                GameManager.GameOver();
                return;
            }
        }
    }

    class Field
    {
        public readonly Vector2 pos;
        private Enemy enemy;
        public Enemy Enemy
        {
            get { return enemy; }
            set
            {
                if (value != null)
                {
                    enemy = value;
                    enemy.gameObject.transform.position = pos;
                }
                else
                {
                    enemy = value;
                }
            }
        }

        public Field(int x, int y)
        {
            pos = new Vector2(x, y);
        }
    }
}
