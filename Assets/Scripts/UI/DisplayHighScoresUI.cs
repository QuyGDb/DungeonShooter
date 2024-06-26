using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHighScoresUI : MonoBehaviour
{
    #region Header OBJECT REFERENCES
    [Header("OBJECT REFERENCES")]
    #endregion
    #region Tooltip
    [Tooltip("Populate this with the child COntent gameobject Transform")]
    #endregion
    [SerializeField] Transform contentAnchorTransfrom;

    private void Start()
    {
        DisplayScores();
    }

    private void DisplayScores()
    {
        HighScores highScores = HighScoreManager.Instance.GetHighScores();
        GameObject scoreGameobject;

        // Loop through scores
        int rank = 0;

        foreach (Score score in highScores.scoreList)
        {
            rank++;

            // Instantiate scores gameobject
            scoreGameobject = Instantiate(GameResources.Instance.scorePrefab, contentAnchorTransfrom);

            ScorePrefab scorePrefab = scoreGameobject.GetComponent<ScorePrefab>();

            //Populate
            scorePrefab.rankTMP.text = rank.ToString();
            scorePrefab.nameTMP.text = score.playerName;
            scorePrefab.levelTMP.text = score.levelDescription;
            scorePrefab.scoreTMP.text = score.playerScore.ToString();
        }

        // Add blank line
        // Instantiate scores gameobject
        scoreGameobject = Instantiate(GameResources.Instance.scorePrefab, contentAnchorTransfrom);
    }
}
