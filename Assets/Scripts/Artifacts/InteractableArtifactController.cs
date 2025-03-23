using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableArtifactController : MonoBehaviour
{
    [SerializeField] private ArtifactInfoSO artifactData;

    [Header("Canvas References")]
    [SerializeField] private GameObject informationCanvas;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private ScrollRect scrollRect;

    private void Start()
    {
        informationCanvas.SetActive(false);

        titleText.text = artifactData.artifactName;
        descriptionText.text = artifactData.artifactDescription;

        StartCoroutine(UpdateTextHeight());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            informationCanvas.SetActive(true);
            StartCoroutine(UpdateTextHeight());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            informationCanvas.SetActive(false);
        }
    }

    private IEnumerator UpdateTextHeight()
    {
        yield return new WaitForEndOfFrame();

        LayoutRebuilder.ForceRebuildLayoutImmediate(descriptionText.rectTransform);

        scrollRect.verticalNormalizedPosition = 1f;
    }
}
