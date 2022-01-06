using GameDevProject.Entities.Animations;
using GameDevProject.Input;
using GameDevProject.Input.EnemyAI;
using GameDevProject.Interfaces;
using GameDevProject.Managers;
using GameDevProject.Map;
using GameDevProject.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Entities
{
    class Type2Enemy : Enemy
    {
        #region Enemy Properties
        private Type2EnemyAI enemyAI;

        private const int WALK_FRAMES = 7;
        private const int DEAD_FRAMES = 15;

        private const int WALK_FPS = 10;
        private const int DEAD_FPS = 15;
        #endregion

        #region Constructor
        public Type2Enemy(List<Texture2D> textures, Player player, Vector2 position)
        {
            this.textures = textures;
            this.MaxVelocity = new Vector2(1, 2);
            this.Velocity = new Vector2(0, 0);
            this.HitboxRectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);
            this.Position = new Vector2((position.X * 16) - 16, (position.Y * 16) - this.HitboxRectangle.Height);
            this.enemyAI = new Type2EnemyAI(player, this);
            this.InputReader = enemyAI;
            this.Health = 1;

            this.DeathDuration = TimeSpan.FromSeconds(1);
            this.DeathTimer = TimeSpan.Zero;

            AddAnimations();
            SetAnimations();
        }
        #endregion

        #region Enemy Methods
        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
            this.enemyAI.TryJump(gameTime);
        }
        #endregion

        #region Animations
        private void AddAnimations()
        {
            this.animations.Add(new Animation(WALK_FPS));
            this.animations.Add(new Animation(DEAD_FPS));
        }

        private void SetAnimations()
        {
            this.animations[0].GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, WALK_FRAMES, 1);
            this.animations[1].GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, DEAD_FRAMES, 1);
        }
        #endregion
    }
}
