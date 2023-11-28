using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private DataBullet defaultBullet = null;

        [SerializeField] private BoxCollider2D activeArea = null;

        //A dictionary that map bullet type to list of bullet caches
        private readonly Dictionary<DataBullet, List<Bullet>> bulletCaches = new Dictionary<DataBullet, List<Bullet>>();

        //create a function to initiate the cache from a list of bullet templates
        public void InitiateCache(List<DataBullet> bulletTemplates)
        {
            //loop through the list of bullet templates
            for (int i = 0; i < bulletTemplates.Count; i++)
            {
                //initiate the cache for each bullet template
                InitiateCache(bulletTemplates[i]);
            }
        }

        public void InitiateCache(DataBullet templateBullet)
        {
            if (bulletCaches.ContainsKey(templateBullet) == false)
                bulletCaches.Add(templateBullet, new List<Bullet>());

            var cache = bulletCaches[templateBullet];

            //destroy all the bullets in the cache and clear the cache
            for (int i = 0; i < cache.Count; i++)
            {
                Destroy(cache[i].gameObject);
            }
            cache.Clear();

            //instantiate 10 bullets and put them in the cache
            for (int i = 0; i < 10; i++)
            {
                var newBullet = Instantiate(templateBullet.Prefab, transform);
                newBullet.gameObject.SetActive(false);
                cache.Add(newBullet);
            }
        }

        Bullet GetBullet()
        {
            return GetBullet(defaultBullet);
        }

        Bullet GetBullet(DataBullet templateBullet)
        {
            //if template bullet is null then use the default bullet
            if (templateBullet == null)
                templateBullet = defaultBullet;

            if (bulletCaches.ContainsKey(templateBullet) == false)
                InitiateCache(templateBullet);

            var bullets = bulletCaches[templateBullet];
            //loop through the bullets in the cache
            for (int i = 0; i < bullets.Count; i++)
            {
                //check if the bullet is not active
                if (!bullets[i].gameObject.activeSelf)
                {
                    //return the bullet
                    return bullets[i];
                }
            }

            //if there is no bullet in the cache, instantiate a new bullet and put it in the cache
            var newBullet = Instantiate(templateBullet.Prefab, transform);
            bullets.Add(newBullet);
            return newBullet;
        }

        public void SpawnBullet(GameObject owner, Vector2 direction)
        {
            //get a bullet from the cache
            var bullet = GetBullet();
            bullet.Spawn(owner, direction, activeArea);
        }

        public void SpawnBullet(DataBullet data, GameObject owner, Vector2 direction)
        {
            //get a bullet from the cache of the data bullet
            var bullet = GetBullet(data);
            bullet.Spawn(owner, direction, activeArea);
        }
    }
}