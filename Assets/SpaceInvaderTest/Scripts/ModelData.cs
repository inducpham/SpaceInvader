using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class ModelData : MonoBehaviour
    {
        [SerializeField] private DataShipDisplay defaultSkin;
        public DataShipDisplay DefaultSkin => defaultSkin;

        [SerializeField] private List<DataShipDisplay> shipSkins;
        public List<DataShipDisplay> ShipSkins => shipSkins;

        [SerializeField] private List<DataBullet> bullets;
        public List<DataBullet> Bullets => bullets;

        [SerializeField] private List<DataEnemy> enemies;
        public List<DataEnemy> Enemies => enemies;

        public void SetupData()
        {
        }

        public DataEnemy GetRandomEnemyData()
        {
            //if enemies is empty return null
            if (enemies.Count == 0) return null;
            //return random enemy data
            return enemies[Random.Range(0, enemies.Count)];
        }

        public DataShipDisplay GetRandomSpaceshipSkin()
        {
            //if shipSkins is empty return defaultSkin
            if (shipSkins.Count == 0) return defaultSkin;
            //return random ship skin
            return shipSkins[Random.Range(0, shipSkins.Count)];
        }

        public DataBullet GetRandomBulletData()
        {
            //if bullets is empty return null
            if (bullets.Count == 0) return null;
            //return random bullet data
            return bullets[Random.Range(0, bullets.Count)];
        }

#if UNITY_EDITOR

        [ContextMenu("Collect all data")]
        public void CollectAllData()
        {
            //collectalldata shipskin
            CollectAllData(ref shipSkins);
            CollectAllData(ref bullets);
            CollectAllData(ref enemies);

            //unityeditor set this object dirty
            UnityEditor.EditorUtility.SetDirty(this);
        }

        public void CollectAllData<T>(ref List<T> targetList) where T:ScriptableObject
        {
            if (targetList == null) targetList = new List<T>();
            //clear target list
            targetList.Clear();
            //find all ScriptableObjects in the project that is of type T and add them into targetList
            string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).FullName);
            foreach (string guid in guids)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                //print the path
                Debug.Log(path);
                T asset = UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(T)) as T;
                if (asset != null)
                {
                    targetList.Add(asset);
                }
            }
        }
#endif



    }

}