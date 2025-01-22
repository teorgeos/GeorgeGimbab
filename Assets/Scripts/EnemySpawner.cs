using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float[] arrPosX = { -2f, -0.7f, 0.7f, 2f };

    [SerializeField]
    private GameObject enemy;

    private float spawnInterval = 0.3f;

    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            // 랜덤한 X 위치 선택
            float posX = arrPosX[Random.Range(0, arrPosX.Length)];

            // 적 생성
            SpawnEnemy(posX);

            // 다음 스폰까지 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
