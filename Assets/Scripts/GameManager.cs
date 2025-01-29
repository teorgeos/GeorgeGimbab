using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 패턴

    public int enemyKillCount = 0; // 적 처치 수
    public int maxKills = 100; // 목표 처치 수
    public Slider loadingBar; // 로딩 바 UI
    public GameObject gameOverPanel; // 게임 오버 UI

    private void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        gameOverPanel.SetActive(false); // 게임 오버 UI 숨김
        loadingBar.value = 0; // 로딩바 초기화
    }

    public void EnemyKilled()
    {
        enemyKillCount++; // 처치 수 증가
        loadingBar.value = (float)enemyKillCount / maxKills; // 로딩 바 업데이트

        if (enemyKillCount >= maxKills)
        {
            GameOver(); // 게임 오버 실행
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); // 게임 오버 UI 표시
        Time.timeScale = 0; // 게임 정지
    }
}
