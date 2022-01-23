using System;
using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        public GameObject healthBarPrefab;
        // [HideInInspector]
        public GameObject healthIns;
        public float maxHealth;
        public float xOffset;
        public float yOffset;
        
        public Image health;
        
        private void Start()
        {
            healthIns = Instantiate(healthBarPrefab, transform.position, Quaternion.identity,
                GameObject.Find("Canvas").transform);
            health = healthIns.transform.GetChild(0).GetComponent<Image>();
            HideHealth();
        }

        // Update is called once per frame
        void Update()
        {
            HealthFollow();
        }

        public void HealthFollow()
        {
            var screenPos =
                Camera.main.WorldToScreenPoint(gameObject.transform.position + new Vector3(xOffset, yOffset, 0));
                             healthIns.transform.position = screenPos;
        }

        public void ChangeHealth(float currentHealth)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            health.fillAmount = currentHealth / maxHealth;
            ShowHealth();
            CancelInvoke("HideHealth");
            Invoke("HideHealth", 3f);
        }

        public void HideHealth()
        {
            healthIns.gameObject.SetActive(false);
        }

        public void ShowHealth()
        {
            healthIns.gameObject.SetActive(true);
        }
    }
}
