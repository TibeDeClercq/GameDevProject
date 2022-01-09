using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Blob.Entities.Animations;
using Blob.Input.EnemyAI;
using Blob.Map;

namespace Blob.Entities
{
    class Type2Enemy : Enemy
    {
        #region Type2Enemy Properties
        private Type2EnemyAI enemyAI;

        private const int WALK_FRAMES = 7;
        private const int DEAD_FRAMES = 15;
        private const int IDLE_FRAMES = 6;

        private const int WALK_FPS = 10;
        private const int DEAD_FPS = 15;
        private const int IDLE_FPS = 6;
        #endregion

        #region Constructor
        public Type2Enemy(List<Texture2D> textures, Player player, Vector2 coordinates)
        {
            this.textures = textures;

            this.MaxVelocity = new Vector2(1, 2);
            this.Velocity = new Vector2(0, 0);
            this.Gravity = new Vector2(0, 0.2f);
            this.HitboxRectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);
            this.Position = new Vector2((coordinates.X * 16) - 16, (coordinates.Y * 16) - this.HitboxRectangle.Height);
            this.enemyAI = new Type2EnemyAI(player, this, 300);
            this.InputReader = enemyAI;
            this.Health = 1;

            this.DeathDuration = TimeSpan.FromSeconds(1);
            this.DeathTimer = TimeSpan.Zero;

            AddAnimations();
            SetAnimations();
            SetHitboxes();
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
            this.animations.Add(new Animation(WALK_FPS, WALK_FRAMES));
            this.animations.Add(new Animation(DEAD_FPS, DEAD_FRAMES));
            this.animations.Add(new Animation(IDLE_FPS, IDLE_FRAMES));
        }

        private void SetAnimations()
        {
            for (int i = 0; i < this.animations.Count; i++)
            {
                this.animations[i].GetFramesFromTextureProperties(textures[i].Width, textures[i].Height, 1);
            }
        }

        private void SetHitboxes()
        {
            this.animations[0].Hitbox = new Rectangle(0, 12, 32, 20);
            this.animations[1].Hitbox = new Rectangle(0, 12, 32, 20);
            this.animations[2].Hitbox = new Rectangle(0, 12, 32, 20);

            this.IdleHitboxWidth = this.animations[2].Hitbox.Width - 1;
        }
        #endregion
    }
}
