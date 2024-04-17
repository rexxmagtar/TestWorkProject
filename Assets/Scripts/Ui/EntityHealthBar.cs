using UnityEngine;
using UnityEngine.UI;

public class EntityHealthBar : MonoBehaviour
{
    [field:SerializeField]
    private Slider HealthBarSlider { get; set; }

	[field: SerializeField]
	private GameEntity GameEntity { get; set; }

	// Start is called before the first frame update
	void Start()
    {
        HealthBarSlider.maxValue = GameEntity.Health;
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarSlider.value = GameEntity.Health;
    }
}
