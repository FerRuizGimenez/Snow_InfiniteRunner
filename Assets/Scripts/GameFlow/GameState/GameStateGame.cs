using UnityEngine;
using TMPro;

public class GameStateGame : GameState
{
    public GameObject gameUI;
    [SerializeField] private TextMeshProUGUI fishCount;
    [SerializeField] private TextMeshProUGUI scoreCount;
    public override void Construct()
    {
        base.Construct();
        GameManager.Instance.motor.ResumePlayer();
        GameManager.Instance.ChangeCamera(GameCamera.Game);

        GameStats.Instance.OnCollectFish += OnCollectFish;
        GameStats.Instance.OnScoreChange += OnScoreChange;
        // Lambda
        //GameStats.Instance.OnScoreChange += (s) => { scoreCount.text = s.ToString(); };

        gameUI.SetActive(true);
    }
    private void OnCollectFish(int amnCollected)
    {
        fishCount.text = GameStats.Instance.FishToText();
    }
    private void OnScoreChange(float score)
    {
        scoreCount.text = GameStats.Instance.ScoreToText();
    }
    public override void Destruct()
    {
        gameUI.SetActive(false);

        GameStats.Instance.OnCollectFish -= OnCollectFish;
        GameStats.Instance.OnScoreChange -= OnScoreChange;
    }
    public override void UpdateState()
    {
        GameManager.Instance.worldGeneration.ScanPosition();
        GameManager.Instance.sceneChunkGeneration.ScanPosition();
    }
}
