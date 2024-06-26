using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    #region Tooltip
    [Tooltip("Populate with the music volume level")]
    #endregion Tooltip
    [SerializeField] private TextMeshProUGUI musicLevelText;
    #region Tooltip
    [Tooltip("Populate with the sounds volume level")]
    #endregion Tooltip
    [SerializeField] private TextMeshProUGUI soundLevelText;
    private void Start()
    {
        // Initially hide the pause menu
        gameObject.SetActive(false);
    }

    private IEnumerator InitializeUI()
    {
        // Wait a frame to ensure the previous music and sound levels have been set
        yield return null;

        // Initialise UI text
        soundLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
        StartCoroutine(InitializeUI());
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    // quit and load main menu - linked to from pause mnenu UI button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    /// <summary>
    /// Increase music volume - linked to from music volume increase button in UI
    /// </summary>
    public void IncreaseMusicVolume()
    {
        MusicManager.Instance.IncreaseMusicVolume();
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }
    /// <summary>
    /// Decrease music volume - linked to from music volume decrease button in UI
    /// </summary>
    public void DecreaseMusicVolume()
    {
        MusicManager.Instance.DecreaseMusicVolume();
        musicLevelText.SetText(MusicManager.Instance.musicVolume.ToString());
    }
    /// <summary>
    /// Increase sounds volume - linked to from sounds volume increase button in UI
    /// </summary>
    public void IncreaseSoundVolume()
    {
        SoundEffectManager.Instance.IncreaseSoundsVolume();
        soundLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
    }
    /// <summary>
    /// Decrease sounds volume - linked to from sounds volume decrease button in UI
    /// </summary>
    public void DecreaseSoundVolume()
    {
        SoundEffectManager.Instance.DecreaseSoundVolume();
        soundLevelText.SetText(SoundEffectManager.Instance.soundsVolume.ToString());
    }

    #region Vadidation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(musicLevelText), musicLevelText);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundLevelText), soundLevelText);

    }
#endif
    #endregion
}
