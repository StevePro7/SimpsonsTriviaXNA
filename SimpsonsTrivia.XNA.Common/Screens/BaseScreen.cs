using System;
using Microsoft.Xna.Framework;

namespace WindowsGame.Common.Screens
{
	public abstract class BaseScreen
	{
		protected UInt16 Timer { get; set; }
		protected Vector2 BannerPosition { get; set; }

		public virtual void Initialize()
		{
		}

		public virtual void LoadContent()
		{
			Timer = 0;
		}

		protected void UpdateTimer(GameTime gameTime)
		{
			Timer += (UInt16)gameTime.ElapsedGameTime.Milliseconds;
		}

		public virtual void Draw()
		{
		}
	}
}