using System;
using WindowsGame.Common.Data;
using WindowsGame.Common.Implementation;
using WindowsGame.Common.Library.Interfaces;
using WindowsGame.Common.Library.Managers;
using WindowsGame.Common.Static;
using WindowsGame.SystemTests.Implementation;
using NUnit.Framework;

namespace WindowsGame.SystemTests.Library.Managers
{
	[TestFixture]
	public class FileManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			FileManager = MyGame.Manager.FileManager;
		}

		[Test]
		public void LoadTxtTest()
		{
			DifficultyType type = DifficultyType.Easy;

			String file = String.Format("{0}{1}/{2}/{3}/{4}.txt", CONTENT_ROOT, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY,
				Constants.LEVELS_DIRECTORY, type);

			var data = FileManager.LoadTxt(file);
			Console.WriteLine("Number Lines: " + data.Count);
		}

		[Test]
		public void LoadXmlTest()
		{
			String file = String.Format("{0}{1}/{2}/{3}/{4}", CONTENT_ROOT, Constants.CONTENT_DIRECTORY, Constants.DATA_DIRECTORY,
				Constants.CONFIG_DIRECTORY, Constants.GLOBAL_CONFIG_FILENAME);

			var configData = FileManager.LoadXml<GlobalConfigData>(file);
			Console.WriteLine("Splash delay:" + configData.SplashDelay);
		}

		[TearDown]
		public void TearDown()
		{
			FileManager = null;
		}
	}
}