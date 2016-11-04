using UnityEngine;
using UnityEngine.UI;

public class SliderInput : MonoBehaviour {
    [SerializeField]
    Slider _widthSlider;

    [SerializeField]
    Slider _heightSlider;

    bool _updated = false;

    public int width {
        get { return (int)Mathf.Round(_widthSlider.value); }
    }

    public int height {
        get { return (int)Mathf.Round(_heightSlider.value); }
    }

    public bool updated {
        get { return _updated; }
    }

    Vector2 _lastKnownValues = new Vector2(0, 0);

    void Update() {
        if (width != _lastKnownValues.x || height != _lastKnownValues.y) {
            _updated = true;
        } else {
            _updated = false;
        }

        _lastKnownValues.x = width;
        _lastKnownValues.y = height;
    }
}
