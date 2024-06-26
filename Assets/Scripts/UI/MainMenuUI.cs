using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region Header OBJECT REFERENCES
    [Header("OBJECT REFERENCES")]
    #endregion
    [SerializeField] private GameObject playButton;
    #region Tooltip
    [Tooltip("Populate with the quit button gameobject")]
    #endregion
    [SerializeField] private GameObject quitButton;

    [SerializeField] private GameObject highScoresButton;
    #region Tooltip
    [Tooltip("Populate with the instructions button gameobject")]
    #endregion
    [SerializeField] private GameObject instructionsButton;
    #region Tooltip
    [Tooltip("Populate with the return to main menu button gameobject")]
    #endregion
    [SerializeField] private GameObject returnToMainMenuButton;
    private bool isHighScoresSceneLoaded = false;
    private bool isInstructionSceneLoad = false;
    private void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);

        // Load Character selectior scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);
        returnToMainMenuButton.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadHighScore()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isHighScoresSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load High Score scene additively
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
    }

    public void LoadCharacterSelector()
    {
        returnToMainMenuButton.SetActive(false);

        if (isHighScoresSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("HighScoreScene");
            isHighScoresSceneLoaded = false;
        }
        else if (isInstructionSceneLoad)
        {
            SceneManager.UnloadSceneAsync("InstructionsScene");
            isInstructionSceneLoad = false;
        }

        playButton.SetActive(true);
        quitButton.SetActive(true);
        highScoresButton.SetActive(true);
        instructionsButton.SetActive(true);

        // Load Character selectior scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);

    }

    /// <summary>
    /// Called from the Instruction Button
    /// </summary>
    public void LoadInstructions()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isInstructionSceneLoad = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load Instructions scene additively
        SceneManager.LoadScene("InstructionsScene", LoadSceneMode.Additive);
    }

    /// <summary>
    ///  Quit the game - this method is called from the onClick event set in the inspector
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered 
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(playButton), playButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(quitButton), quitButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(highScoresButton), highScoresButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(instructionsButton), instructionsButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(returnToMainMenuButton), returnToMainMenuButton);

    }
#endif
    #endregion
}

