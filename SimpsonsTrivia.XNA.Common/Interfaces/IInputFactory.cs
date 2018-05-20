﻿using System;
using Microsoft.Xna.Framework;

namespace WindowsGame.Common.Interfaces
{
	public interface IInputFactory
	{
		void Initialize();
		void Update(GameTime gameTime);

		Boolean Escape();
		Boolean Advance();
		Boolean LeftArrow();
		Boolean RghtArrow();
		Boolean VolumeIcon();
	}
}