using UnityEngine;

[CreateAssetMenu(fileName = "NewArtifactInfo", menuName = "ScriptableObjects/ArtifactInfo")]
public class ArtifactInfoSO : ScriptableObject
{
    public string artifactName;
    public string artifactInfo;
    [TextArea] public string artifactDescription;
    public AudioClip artifactAudio;
}
