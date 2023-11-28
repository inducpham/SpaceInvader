using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background = null;
        [SerializeField] private float _speed = 4f;
                
        private List<SpriteRenderer> _backgrounds = new List<SpriteRenderer>();
        //define negative gapfilloffset to make sure there is no gap between the backgrounds
        private float _gapFillOffset = 0.1f;

        private void Start()
        {
            //put the background to the list, and instantiate another background to the same parent and add them to the list
            _backgrounds.Add(_background);
            _backgrounds.Add(Instantiate(_background, new Vector2(0, _background.bounds.size.y), Quaternion.identity, _background.transform.parent));

            //put the backgrounds next to eachothers vertically
            for (int i = 0; i < _backgrounds.Count; i++)
            {
                _backgrounds[i].transform.position = transform.position + new Vector3(0, _backgrounds[i].bounds.size.y - _gapFillOffset, -_gapFillOffset) * i;
            }
        }

        private void Update()
        {
            //move the backgrounds down
            for (int i = 0; i < _backgrounds.Count; i++)
            {
                _backgrounds[i].transform.position += Vector3.down * _speed * Time.deltaTime;
            }

            //check if the background is out of the screen
            if (_backgrounds[0].transform.position.y < -_backgrounds[0].bounds.size.y)
            {
                //put the background at the end of the list
                _backgrounds[0].transform.position = new Vector3(0, _backgrounds[_backgrounds.Count - 1].transform.position.y + _backgrounds[_backgrounds.Count - 1].bounds.size.y - _gapFillOffset, _backgrounds[0].transform.position.z);

                //put the background at the end of the list
                _backgrounds.Add(_backgrounds[0]);

                //remove the background from the start of the list
                _backgrounds.RemoveAt(0);
            }
        }

    }

}