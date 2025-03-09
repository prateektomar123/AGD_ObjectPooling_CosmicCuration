using System;
using System.Collections;
using System.Collections.Generic;
using CosmicCuration.Enemy;
using UnityEngine;
using static CosmicCuration.Enemy.EnemyPool;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T: class 
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("My Child Class Dont have Implementation of CreateItem()");
        }
        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }
}
