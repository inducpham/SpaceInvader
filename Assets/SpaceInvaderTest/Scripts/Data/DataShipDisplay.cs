using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    //generate class DataShipSkin : ScriptableObject and add the attribute CreateAssetMenu
    [CreateAssetMenu(fileName = "DataShipSkin", menuName = "Data/DataShipSkin")]
    public class DataShipDisplay : ScriptableObject
    {
        [SerializeField] private string code;
        [SerializeField] private string fullname;
        [SerializeField] private SpaceShipDisplay spaceShipDisplay;

        public string Code => code;
        public string Fullname => fullname;
        public SpaceShipDisplay SpaceShipDisplay => spaceShipDisplay;
    }
}