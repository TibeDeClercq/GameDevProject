using System.Collections.Generic;
using System.Diagnostics;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.Managers;
using GameDevProject.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class GameOverLevel2State : IGameState
    {
        #region Properties
        private SpriteFont font;
        private List<Button> buttons;
        #endregion

        #region Constructor
        public GameOverLevel2State(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<Button>();

            this.buttons.Add(new Button(new Vector2(4, 6), new Vector2(4, 2), "Retry"));
            this.buttons.Add(new Button(new Vector2(13, 6), new Vector2(6, 2), "Main Menu"));
        }
        #endregion

        #region Public methods
        public void Update(Level level, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            foreach (Button button in this.buttons)
            {
                if (mouse.X / Game1.Scale >= button.Position.X && mouse.X / Game1.Scale <= button.Position.X + button.Size.X)
                {
                    if (mouse.Y / Game1.Scale >= button.Position.Y && mouse.Y / Game1.Scale <= button.Position.Y + button.Size.Y)
                    {
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            if (button == buttons[0])
                            {
                                Game1.State = State.Level2;
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
            level.World.Draw(spriteBatch);

            spriteBatch.DrawString(this.font, "Game Over Level 2", new Vector2((level.World.GetWorldWidth() / 2) - 65, 8), Color.White);
            spriteBatch.DrawString(this.font, $"Score: {ScoreManager.Score}", new Vector2((level.World.GetWorldWidth() / 2) - 30, 23), Color.White);

            foreach (Button button in this.buttons)
            {
                spriteBatch.DrawString(this.font, button.Text, button.TextPosition, Color.White);
            }
        }


        public int GetWindowHeight(Level level)
        {
            return level.World.GetWorldHeight();
        }

        public int GetWindowWidth(Level level)
        {
            return level.World.GetWorldWidth();
        }
        #endregion
    }
}
