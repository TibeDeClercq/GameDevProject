using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        #region Public methods
        public void Move(IMovable movable, GameTime gameTime, World world)
        {
            this.CheckLevelComplete(movable, world);

            var input = movable.InputReader.ReadInput();

            movable.Velocity = new Vector2(0, 0);
            PhysicsManager.AddGravity(movable, world);
            PhysicsManager.AddJump(movable, world);

            var entity = movable as Entity;
            if (entity.Health > 0)
            {
                if (input.DirectionInput.X == -1)
                {
                    movable.SpriteEffects = SpriteEffects.FlipHorizontally;
                    PhysicsManager.MoveLeft(movable, world);
                }
                if (input.DirectionInput.X == 1)
                {
                    movable.SpriteEffects = SpriteEffects.None;
                    PhysicsManager.MoveRight(movable, world);
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
                    PhysicsManager.Drop(movable, world);
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
