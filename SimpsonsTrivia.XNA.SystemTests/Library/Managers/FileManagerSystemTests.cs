﻿using System;
using WindowsGame.Data;
using WindowsGame.Implementation;
using WindowsGame.Library.Interfaces;
using WindowsGame.Library.Managers;
using WindowsGame.Static;
using WindowsGame.SystemTests.Implementation;
using NUnit.Framework;

namespace WindowsGame.SystemTests.Library.Managers
{
	[TestFixture]
	public class FileManagerSystemTests : BaseSystemTests
	{
		private IFileManager fileManager;

		[SetUp]
		public void SetUp()
		{
			IFileProxy fileProxy = new TestFileProxy();
			fileManager = new FileManager(fileProxy);
		}

		[Test]
		public void LoadTxtTest()
		{
			String file = String.Format("{0}{1}/{2}/{3}/{4}{5}/{6}{7}.txt", CONTENT_ROOT, Constants.CONTENT_DIRECTORY,
				Constants.DATA_DIRECTORY, Constants.LEVELS_DIRECTORY, Constants.WORLD_FILENAME, world, Constants.ROUND_FILENAME,
				round);

			//var levelData = FileManager.LoadTxt(file);
			//Console.WriteLine("LevelData:" + levelData.Count);
		}

		[Test]
		public void LoadXmlTest()
		{
			String file = String.Format("{0}{1}/{2}/{3}/{4}", CONTENT_ROOT, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY,
			    Constants.CONFIG_DIRECTORY, Constants.GLOBAL_CONFIG_FILENAME);

			var configData = fileManager.LoadXml<GlobalConfigData>(file);
			Console.WriteLine("Splash delay:" + configData.SplashDelay);
		}

		[TearDown]
		public void TearDown()
		{
			fileManager = null;
		}
	}
}