using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIView : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI HighScoreText;
    public RectTransform HealthBar;
    public GameObject DeathOverlay;
    public int HighScore = 0;

    public void UpdateHealthBar(float health, float maxHealth)
    {
        if(health < 0) health = 0;
        HealthBar.sizeDelta = new Vector2((health/maxHealth) * 280, HealthBar.sizeDelta.y);
    }

    public void ApplyDeathOverlay()
    {
        DeathOverlay.SetActive(true);
    }

    public void AddToHighScore(int score)
    {
        HighScore += score;
        HighScoreText.text = HighScore.ToString();
    }
}
