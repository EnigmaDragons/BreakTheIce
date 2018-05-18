using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ParticleLineGenerator : MonoBehaviour
    {
        public float ParticleDistance = 1f;
        public Vector3 RotationOffset = Vector3.zero;

        public ParticleSystem System;
        public ParticleSystemRenderer Renderer;
        public Vector3 Source;
        public Vector3 Dest;

        private void Start ()
        {
            GenerateLine();
        }

        private void OnEnable()
        {
            GenerateLine();
        }

        private void GenerateLine()
        {
            var totalDistance = Vector3.Distance(Source, Dest);
            var particleCount = (int)Mathf.Floor(totalDistance / ParticleDistance);
            var particles = Enumerable.Range(0, particleCount).Select(x => GenerateParticle(totalDistance, x)).ToArray();
            System.SetParticles(particles, particleCount);
            MagicThatMakesItWork(particleCount);
        }

        private ParticleSystem.Particle GenerateParticle(float totalDistance, int index)
        {
            return new ParticleSystem.Particle
            {
                position = Vector3.MoveTowards(Source, Dest, (totalDistance % ParticleDistance) / 2 + index * ParticleDistance),
                startSize = System.main.startSize.constant,
                startColor = Color.white,
                rotation3D = Quaternion.LookRotation(Source - Dest).eulerAngles + RotationOffset
            };
        }

        private void MagicThatMakesItWork(int particleCount)
        {
            var customData = new List<Vector4>();
            System.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
            for (int i = 0; i < particleCount; i++)
                customData[i] = this.gameObject.transform.up;
            System.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        }
    }
}
