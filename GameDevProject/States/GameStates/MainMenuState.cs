using System.Collections.Generic;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class MainMenuState : IGameState
    {
        private SpriteFont font;

        private List<Button> buttons;

        public bool CanClick;
        public MainMenuState(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<Button>();
            this.buttons.Add(new Button(new Vector2(4, 6), new Vector2(4, 2), "Level 1"));
            this.buttons.Add(new Button(new Vector2(15, 6), new Vector2(4, 2), "Level 2"));
        }
        public void Update(Level level, GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Released)
            {
                CanClick = true;
            }
            foreach (Button button in buttons)
            {
                if (mouse.X / Game1.Scale >= button.Position.X && mouse.X / Game1.Scale <= button.Position.X + button.Size.X)
                {
                    if (mouse.Y / Game1.Scale >= button.Position.Y && mouse.Y / Game1.Scale <= button.Position.Y + button.Size.Y)
                    {
                        if(mouse.LeftButton == ButtonState.Pressed && CanClick)
                        {
                            if(button == buttons[0])
                            {
                                Game1.State = State.Level1;
                            }
                            else if (button == buttons[1])
                            {
                                Game1.State = State.Level2;
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.world.Draw(spriteBatch);

            spriteBatch.DrawString(this.font, "BLOB", new Vector2((level.world.GetWorldWidth() / 2) - 20, 7), Color.White); //Each letter is 5 pixels

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
