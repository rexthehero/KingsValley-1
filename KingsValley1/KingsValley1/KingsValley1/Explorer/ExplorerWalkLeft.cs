﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KingsValley1
{
    public class ExplorerWalkLeft : AnimatedSprite
    {
        //Fields
        private Explorer explorer;
        //Properties

        //Constructor
        public ExplorerWalkLeft(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.effect = SpriteEffects.FlipHorizontally;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(this.explorer.Speed, 0f);
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.IdleLeft;
            }
            if (Input.EdgeDetectKeyDown(Keys.Space))
            {
                this.explorer.State = this.explorer.JumpLeft;
                this.explorer.JumpLeft.Initialize();
            }
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
