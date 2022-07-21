using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	public static GameOverManager instance;

	private GameObject gameOverPanel;
	private Animator gameOverAnim;

	private Button playAgainBtn, backBtn;

	private GameObject scoreText;
	private Text finalScore;

	void Awake()
	{
		MakeInstance();
		InitializeVariables();
	}

	void MakeInstance()
	{
		if (instance == null)
			instance = this;
	}

	public void GameOverShowPanel()
	{
		scoreText.SetActive(false);
		gameOverPanel.SetActive(true);

		finalScore.text ="Score\n"+ScoreManager.instance.GetScore();

		gameOverAnim.Play("FadeIn");
	}

	void InitializeVariables()
	{
		gameOverPanel = GameObject.Find("GameOverPanelHolder");
		gameOverAnim = gameOverPanel.GetComponent<Animator>();

		playAgainBtn = GameObject.Find("PlayAgainButton").GetComponent<Button>();
		backBtn = GameObject.Find("Back").GetComponent<Button>();

		playAgainBtn.onClick.AddListener(() => PlayAgain());
		backBtn.onClick.AddListener(() => BackToMenu());

		scoreText = GameObject.Find("ScoreText");
		finalScore = GameObject.Find("Final Score").GetComponent<Text>();

		gameOverPanel.SetActive(false);
	}

	public void PlayAgain()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void BackToMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
