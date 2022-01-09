using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameDevProject.Entities.Animations
{
    class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter = 0;
        private double secondCounter = 0;
        private int fps = 0;
        private int frameCount = 0;

        public Rectangle Hitbox { get; set; }

        public Animation(int fps, int frameCount)
        {
            this.fps = fps;
            this.frameCount = frameCount;
            this.frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            this.frames.Add(frame);
            this.CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentFrame = this.frames[counter];

            this.secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (this.secondCounter >= 1d / this.fps)
            {
                this.counter++;
                this.secondCounter = 0;
            }
            if (this.counter >= this.frames.Count)
            {
                this.counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfHeightSprites)
        {
            int widthOfFrame = width / this.frameCount;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    this.frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }

    }
}
