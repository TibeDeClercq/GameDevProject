using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Managers
{
    enum Sound {Coin, Spike, Jump, EnemyJump, Spin, Death, Victory, Defeat, PlayerWalk, EnemyWalk, Dungeon}
    static class SoundManager
    {
        public static List<SoundEffect> SoundEffects { get; set; }

        private static SoundEffectInstance playerWalkSound;
        private static SoundEffectInstance enemyWalkSound;
        private static SoundEffectInstance dungeonSound;

        public static void PlaySound(Sound sound)
        {
            if (sound != Sound.PlayerWalk && sound != Sound.EnemyWalk && sound != Sound.Dungeon && sound != Sound.Coin)
            {
                SoundEffects[(int)sound].Play();
            }

            if (sound == Sound.Coin)
            {
                SoundEffectInstance coin = SoundEffects[(int)sound].CreateInstance();
                coin.Volume = 0.3f;
                coin.Play();
            }

            if (sound == Sound.PlayerWalk && playerWalkSound == null)
            {
                playerWalkSound = SoundEffects[(int)sound].CreateInstance();
                playerWalkSound.IsLooped = true;
                playerWalkSound.Play();
            }
            if (sound == Sound.EnemyWalk && enemyWalkSound == null)
            {
                enemyWalkSound = SoundEffects[(int)sound].CreateInstance();
                enemyWalkSound.IsLooped = true;
                enemyWalkSound.Play();
            }
            if (sound == Sound.Dungeon && dungeonSound == null)
            {
                dungeonSound = SoundEffects[(int)sound].CreateInstance();
                dungeonSound.IsLooped = true;
                dungeonSound.Play();
            }
        }
        public static void StopSound(Sound sound)
        {
            if (sound == Sound.PlayerWalk && playerWalkSound != null)
            {
                playerWalkSound.Stop();
                playerWalkSound = null;
            }
            if (sound == Sound.EnemyWalk && enemyWalkSound != null)
            {
                enemyWalkSound.Stop();
                enemyWalkSound = null;
            }
            if (sound == Sound.Dungeon && dungeonSound != null)
            {
                dungeonSound.Stop();
                dungeonSound = null;
            }
        }
    }
}
