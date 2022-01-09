using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Blob.Entities;
using Blob.Interfaces;
using Blob.Map;

namespace Blob.Managers
{
    class MovementManager
    {
        #region Properties
        private PhysicsManager physicsManager;
        #endregion

        #region Constructor
        public MovementManager()
        {
            this.physicsManager = new PhysicsManager();
        }
        #endregion

        #region Public methods
        public void Move(IMovable movable, GameTime gameTime, World world)
        {
            this.CheckLevelComplete(movable, world);

            var input = movable.InputReader.ReadInput();

            movable.Velocity = new Vector2(0, 0);
            this.physicsManager.AddGravity(movable, world);
            this.physicsManager.AddJump(movable, world);

            var entity = movable as Entity;
            if (entity.Health > 0)
            {
                if (input.DirectionInput.X == -1)
                {
                    movable.SpriteEffects = SpriteEffects.FlipHorizontally;
                    this.physicsManager.MoveLeft(movable, world);
                }
                if (input.DirectionInput.X == 1)
                {
                    movable.SpriteEffects = SpriteEffects.None;
                    this.physicsManager.MoveRight(movable, world);
                }

                if (input.DirectionInput.Y == 1)
                {
                    if (movable.CanJump)
                    {
                        if (movable is Player)
                        {
                            SoundManager.PlaySound(Sound.Jump);
                        }
                        if (movable is Enemy)
                        {
                            SoundManager.PlaySound(Sound.EnemyJump);
                        }
                        movable.Acceleration = new Vector2(0, -3.1f); // power of the jump
                        movable.IsJumping = true;
                    }
                }

                if (input.DirectionInput.Y == -1)
                {
                    this.physicsManager.Drop(movable, world);
                }
            }            

            movable.Velocity += movable.Acceleration;
            movable.Position += movable.Velocity;
        }
        #endregion

        #region Private methods
        private void CheckLevelComplete(IMovable movable, World world)
        {
            foreach (Tile tile in world.GetTiles())
            {
                if (tile.IsFinishCollide)
                {
                    if (movable.HitboxRectangle.Intersects(tile.HitboxRectangle))
                    {
                        switch (Game1.State)
                        {
                            case State.Level1:
                                Game1.State = State.Level1Complete;
                                break;
                            case State.Level2:
                                Game1.State = State.Level2Complete;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        #endregion
    }   
}
