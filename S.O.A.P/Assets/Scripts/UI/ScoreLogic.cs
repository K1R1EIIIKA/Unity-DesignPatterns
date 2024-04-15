using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class ScoreLogic : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _maxScoreText;
        public int Score;
        public int MaxScore;

        private void Start()
        {
            Score = 0;
            MaxScore = SaveProgress.LoadScore();
            _maxScoreText.text = $"Max Score: {MaxScore}";

            StartCoroutine(IncrementScore());
        }

        private IEnumerator IncrementScore()
        {
            yield return new WaitForSeconds(1f);
            Score++;

            StartCoroutine(IncrementScore());
        }

        private void Update()
        {
            _scoreText.text = $"Score: {Score}";
        }
    }
}