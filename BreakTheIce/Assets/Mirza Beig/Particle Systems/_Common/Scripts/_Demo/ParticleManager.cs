﻿
// =================================	
// Namespaces.
// =================================

using UnityEngine;

using System.Collections.Generic;
using System.Linq;

// =================================	
// Define namespace.
// =================================

namespace MirzaBeig
{

    namespace ParticleSystems
    {

        namespace Demos
        {

            // =================================	
            // Classes.
            // =================================
            
            public class ParticleManager : MonoBehaviour
            {
                // =================================	
                // Nested classes and structures.
                // =================================



                // =================================	
                // Variables.
                // =================================

                protected List<ParticleSystems> particlePrefabs;
                protected List<GameObject> particlePrefabLightGameObjects = new List<GameObject>();

                public int currentParticlePrefabIndex;

                // Used for adding prefabs from the project view for 
                // live testing while playing in editor. When finished,
                // add them to the hierarchy and remove them from this
                // list.

                public List<ParticleSystems> particlePrefabsAppend;

                // Take only the part of the prefab name string after these many underscores.

                public int prefabNameUnderscoreCountCutoff = 4;

                // Since I may have prefabs as children I was using to set values.
                // But I don't want to disable/enable them each time I want to run
                // the build or change values. This will auto-disable all at start.

                public bool disableChildrenAtStart = true;

                // Already initialized?

                bool initialized = false;

                // =================================	
                // Functions.
                // =================================

                // ...

                public void init()
                {
                    // Default.

                    //currentParticlePrefab = 0;

                    // Get all particles.

                    particlePrefabs = GetComponentsInChildren<ParticleSystems>(true).ToList();
                    particlePrefabs.AddRange(particlePrefabsAppend);

                    // Disable all particle prefab object children.

                    if (disableChildrenAtStart)
                    {
                        for (int i = 0; i < particlePrefabs.Count; i++)
                        {
                            particlePrefabs[i].gameObject.SetActive(false);
                        }
                    }

                    // Get all GameObjects with light components in all the prefabs.

                    for (int i = 0; i < particlePrefabs.Count; i++)
                    {
                        AnimatedLight[] lights = particlePrefabs[i].GetComponentsInChildren<AnimatedLight>(true);

                        for (int j = 0; j < lights.Length; j++)
                        {
                            particlePrefabLightGameObjects.Add(lights[j].gameObject);
                        }
                    }

                    initialized = true;
                }

                // ...

                protected virtual void Awake()
                {

                }

                // ...

                protected virtual void Start()
                {
                    if (initialized)
                    {
                        init();
                    }
                }

                // ...

                public virtual void next()
                {
                    currentParticlePrefabIndex++;

                    if (currentParticlePrefabIndex > particlePrefabs.Count - 1)
                    {
                        currentParticlePrefabIndex = 0;
                    }
                }

                public virtual void previous()
                {
                    currentParticlePrefabIndex--;

                    if (currentParticlePrefabIndex < 0)
                    {
                        currentParticlePrefabIndex = particlePrefabs.Count - 1;
                    }
                }

                // ...

                public string getCurrentPrefabName(bool shorten = false)
                {
                    // Save object name for clarity.

                    string particleSystemName = particlePrefabs[currentParticlePrefabIndex].name;

                    // Only take name from after the last underscore to the end.

                    if (shorten)
                    {
                        int lastIndexOfUnderscore = 0;

                        for (int i = 0; i < prefabNameUnderscoreCountCutoff; i++)
                        {
                            // -1 if not found, 0 to n otherwise. +1 to move position forward.

                            lastIndexOfUnderscore = particleSystemName.IndexOf("_", lastIndexOfUnderscore) + 1;

                            // Not found. -1 + 1 == 0.

                            if (lastIndexOfUnderscore == 0)
                            {
                                // "Error"... sort of.

                                print("Iteration of underscore not found.");

                                break;
                            }
                        }

                        particleSystemName = particleSystemName.Substring(lastIndexOfUnderscore, particleSystemName.Length - lastIndexOfUnderscore);
                    }

                    // Return display text.

                    return "PARTICLE SYSTEM: #" + (currentParticlePrefabIndex + 1).ToString("00") +
                        " / " + particlePrefabs.Count.ToString("00") + " (" + particleSystemName + ")";
                }

                // ...

                public virtual int getParticleCount()
                {
                    return 0;
                }

                // ...

                public void setLights(bool value)
                {
                    for (int i = 0; i < particlePrefabLightGameObjects.Count; i++)
                    {
                        particlePrefabLightGameObjects[i].SetActive(value);
                    }
                }

                // ...

                protected virtual void Update()
                {

                }

                // =================================	
                // End functions.
                // =================================

            }

            // =================================	
            // End namespace.
            // =================================

        }

    }

}

// =================================	
// --END-- //
// =================================
