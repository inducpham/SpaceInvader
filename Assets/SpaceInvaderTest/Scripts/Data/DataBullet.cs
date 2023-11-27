using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{

    [CreateAssetMenu(fileName = "DataBullet", menuName = "Data/DataBullet")]
    public class DataBullet : ScriptableObject
    {
        [SerializeField] private string code;
        [SerializeField] private string fullname;
        [SerializeField] private Bullet prefab;

        //getters
        public string Code { get => code; }
        public string Fullname { get => fullname; }
        public Bullet Prefab { get => prefab; }

    }
}