using System;
using EventBusLogic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DeathLogic : MonoBehaviour
    {
        [SerializeField] private GameObject _deathScreen;
        [SerializeField] private ScoreLogic _scoreLogic;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _maxScoreText;

        private void Start()
        {
            Time.timeScale = 1;
            EventBus.Instance.AddListener(GameEvent.OnPlayerDied, Lose);
        }

        private void Lose()
        {
            _deathScreen.SetActive(true);
            SaveProgress.SaveMaxScore(_scoreLogic.Score);
            
            _scoreText.text = $"Score: {_scoreLogic.Score}";
            _maxScoreText.text = $"Max Score: {SaveProgress.LoadScore()}";
            
            Time.timeScale = 0;
        }
    }
}