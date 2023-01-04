using System.Collections.Generic;
using UnityEngine;

namespace MonoOptimization
{
    public abstract class MonoModule : MonoBehaviour
    {
        public virtual IEnumerable<object> ProvideObjects()
        {
            yield break;
        }
        
        public virtual void Construct(MonoContextModular context)
        {
        }
    }
}