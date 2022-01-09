using System.Collections.Generic;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.Managers;
using GameDevProject.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class GameOverLevel1State : IGameState
    {
        private SpriteFont font;

        private List<Button> buttons;

        public GameOverLevel1State(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<Button>();
            this.buttons.Add(new Button(new Vector2(4, 6), new Vector2(4, 2), "Retry"));
            this.buttons.Add(new Button(new Vector2(13, 6), new Vector2(6, 2), "Main Menu"));
        }
        public void Update(Level level, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            
            foreach (Button button in buttons)
            {
                if (mouse.X / Game1.Scale >= button.Position.X && mouse.X / Game1.Scale <= button.Position.X + button.Size.X)
                {
                    if (mouse.Y / Game1.Scale >= button.Position.Y && mouse.Y / Game1.Scale <= button.Position.Y + button.Size.Y)
                    {
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            if (button == buttons[0])
                            {
                                Game1.State = State.Level1;
                            }
                            else if (button == buttons[1])
                            {
                                Game1.State = State.MainMenu;
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.world.Draw(spriteBatch);

            spriteBatch.DrawString(this.font, "Game Over Level 1", new Vector2((level.world.GetWorldWidth() / 2) - 65, 8), Color.White);
            spriteBatch.DrawString(this.font, $"Score: {ScoreManager.Score}", new Vector2((level.world.GetWorldWidth() / 2) - 30, 23), Color.White);

            foreach (Button button in buttons)
            {
                spriteBatch.DrawString(this.font, button.Text, button.TextPosition, Color.White);
            }
        }

        public int GetWindowHeight(Level level)
        {
            return level.world.GetWorldHeight(); 
        }

        public int GetWindowWidth(Level level)
        {
            return level.world.GetWorldWidth(); 
        }
    }
}
