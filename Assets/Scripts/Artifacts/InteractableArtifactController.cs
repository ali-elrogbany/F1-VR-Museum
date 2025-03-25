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
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private ScrollRect scrollRect;

    [Header("Audio References")]
    [SerializeField] private AudioClip buttonClickSFX;
    [SerializeField] private AudioSource sfxAudioSource;
    private AudioSource speechAudioSource;

    private void Start()
    {
        speechAudioSource = GetComponent<AudioSource>();

        informationCanvas.SetActive(false);

        titleText.text = artifactData.artifactName;
        infoText.text = artifactData.artifactInfo;
        descriptionText.text = artifactData.artifactDescription;

        StartCoroutine(UpdateTextHeight());
    }

    public void OnButtonClick()
    {
        StartCoroutine(IButtonClick());
    }

    private void PlayAudio()
    {
        speechAudioSource.Stop();
        speechAudioSource.clip = artifactData.artifactAudio;
        speechAudioSource.Play();
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

    private IEnumerator IButtonClick()
    {
        sfxAudioSource.PlayOneShot(buttonClickSFX);

        yield return new WaitForSeconds(1f);

        PlayAudio();
    }
}
