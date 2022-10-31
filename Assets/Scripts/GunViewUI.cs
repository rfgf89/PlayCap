using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunViewUI : MonoBehaviour
{
    [SerializeField] private TypeValue _type;
    [SerializeField] private PrefabGun _prefabGun;
    
    public void SetSlider(Slider slider) => _prefabGun.SetSlider(_type, slider);
    public void SetToggle(Toggle toggle) => _prefabGun.SetToggle(_type, toggle);
    public void SetInput(TMP_InputField tmpInputField) => _prefabGun.SetInputField(_type, tmpInputField);
    
}