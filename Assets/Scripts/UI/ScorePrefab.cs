using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePrefab : MonoBehaviour
{
    public TextMeshProUGUI rankTMP;
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI levelTMP;
    public TextMeshProUGUI scoreTMP;

    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(rankTMP), rankTMP);
        HelperUtilities.ValidateCheckNullValue(this, nameof(nameTMP), nameTMP);
        HelperUtilities.ValidateCheckNullValue(this, nameof(levelTMP), levelTMP);
        HelperUtilities.ValidateCheckNullValue(this, nameof(scoreTMP), scoreTMP);

    }
#endif
    #endregion
}
