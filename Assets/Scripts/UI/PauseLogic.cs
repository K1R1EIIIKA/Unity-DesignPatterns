using Player;
using UnityEngine;

namespace UI
{
    public class PauseLogic : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseScreen;

        private void Start()
        {
            _pauseScreen.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !PlayerLogic.Instance.IsDead)
                SetPause();
        }

        private void SetPause()
        {
            if (Time.timeScale == 0)
                Unpause();
            else
                Pause();
        }

        private void Pause()
        {
            Time.timeScale = 0;
            _pauseScreen.SetActive(true);
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            _pauseScreen.SetActive(false);
        }
    }
}