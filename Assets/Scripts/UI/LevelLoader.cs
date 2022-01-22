using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelLoader : MonoBehaviour
    {
        private GameObject _option;
        private GameObject _loadInterface;
        private Slider _slider;
        private Text _loadPercent;

        private void Awake()
        {
            _option = transform.GetChild(0).gameObject;
            _loadInterface = transform.GetChild(1).gameObject;
            _slider = _loadInterface.transform.GetChild(0).GetComponent<Slider>();
            _loadPercent = _slider.transform.GetChild(2).GetComponent<Text>();
        }

        private void Start()
        {
            _option.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { LoadNextLevel(1); });
            _option.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { QuitGame(); });
        }

        private IEnumerator LoadLevelAsync(int index)
        {
            var operation = SceneManager.LoadSceneAsync(index);
            _loadInterface.SetActive(true);

            while (!operation.isDone)
            {
                var progress = operation.progress;
                _slider.value = progress / 0.9f; //progress的取值是0-0.9
                _loadPercent.text = Mathf.FloorToInt(progress / 0.9f) + "%";
                yield return null;
            }
        }
        
        private void LoadNextLevel(int index)
        {
            _option.SetActive(false);
            _loadInterface.SetActive(true);
            StartCoroutine(LoadLevelAsync(index));
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
