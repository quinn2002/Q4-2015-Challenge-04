using CodeChallenge04_BowlingScorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge04_BowlingScorer_UnitTests
{
	[TestClass]
	public class BowlingFrameValidatorUnitTests
	{
		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void LastFrameIsTenthFrame()
		{
			// Arrange
			var frame1 = new BowlingFrame(1, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame10 = new BowlingFrame(10, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);

			// Act
			var frame1IsTenthFrame = frame1.IsFinalFrame();
			var frame10IsTenthFrame = frame10.IsFinalFrame();

			// Assert
			Assert.IsFalse(frame1IsTenthFrame);
			Assert.IsTrue(frame10IsTenthFrame);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void ValidFrameNumbers()
		{
			// Arrange
			var frameNegative1 = new BowlingFrame(-1, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame0 = new BowlingFrame(0, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame1 = new BowlingFrame(1, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame2 = new BowlingFrame(2, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame10 = new BowlingFrame(10, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Strike);
			var frame11 = new BowlingFrame(11, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);

			// Assert
			Assert.IsFalse(frameNegative1.IsValid());
			Assert.IsFalse(frame0.IsValid());
			Assert.IsTrue(frame1.IsValid());
			Assert.IsTrue(frame2.IsValid());
			Assert.IsTrue(frame10.IsValid());
			Assert.IsFalse(frame11.IsValid());
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void ValidSpares()
		{
			// Arrange
			var frame1 = new BowlingFrame(1, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null);
			var frame2 = new BowlingFrame(2, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Spare);
			var frame3 = new BowlingFrame(3, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame4 = new BowlingFrame(4, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Spare);
			var frame5 = new BowlingFrame(5, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame6 = new BowlingFrame(6, SingleBallScoreEnum.Five, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);

			// Assert
			Assert.IsFalse(frame1.IsValid());
			Assert.IsFalse(frame2.IsValid());
			Assert.IsFalse(frame3.IsValid());
			Assert.IsFalse(frame4.IsValid());
			Assert.IsFalse(frame5.IsValid());
			Assert.IsTrue(frame6.IsValid());
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void ValidStrikes()
		{
			// Arrange
			var frame1 = new BowlingFrame(1, SingleBallScoreEnum.Null, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null);
			var frame2 = new BowlingFrame(2, SingleBallScoreEnum.Five, SingleBallScoreEnum.Five, SingleBallScoreEnum.Strike);
			var frame3 = new BowlingFrame(3, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null);
			var frame4 = new BowlingFrame(4, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike);
			var frame5 = new BowlingFrame(5, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null);
			var frame6 = new BowlingFrame(6, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null);

			// Assert
			Assert.IsFalse(frame1.IsValid());
			Assert.IsFalse(frame2.IsValid());
			Assert.IsFalse(frame3.IsValid());
			Assert.IsFalse(frame4.IsValid());
			Assert.IsFalse(frame5.IsValid());
			Assert.IsTrue(frame6.IsValid());
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void ValidNoStrikesOrSpares()
		{
			// Arrange
			var frame1 = new BowlingFrame(1, SingleBallScoreEnum.Five, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null);
			var frame2 = new BowlingFrame(2, SingleBallScoreEnum.Two, SingleBallScoreEnum.Four, SingleBallScoreEnum.Six);
			var frame3 = new BowlingFrame(3, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Five);
			var frame4 = new BowlingFrame(4, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null);
			var frame5 = new BowlingFrame(5, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null);
			var frame6 = new BowlingFrame(6, SingleBallScoreEnum.Five, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null);
			var frame7 = new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null);

			// Assert
			Assert.IsFalse(frame1.IsValid());
			Assert.IsFalse(frame2.IsValid());
			Assert.IsFalse(frame3.IsValid());
			Assert.IsFalse(frame4.IsValid());
			Assert.IsFalse(frame5.IsValid());
			Assert.IsTrue(frame6.IsValid());
			Assert.IsTrue(frame7.IsValid());
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingFrameValidation")]
		public void ValidTenthFrame()
		{
			// Arrange
			var frame1 = new BowlingFrame(10, SingleBallScoreEnum.Five, SingleBallScoreEnum.Five, SingleBallScoreEnum.Two);
			var frame2 = new BowlingFrame(10, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Spare);
			var frame3 = new BowlingFrame(10, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Null, SingleBallScoreEnum.Five);
			var frame4 = new BowlingFrame(10, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six);
			var frame5 = new BowlingFrame(10, SingleBallScoreEnum.One, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Seven);
			var frame6 = new BowlingFrame(10, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike);
			var frame7 = new BowlingFrame(10, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Six);
			var frame8 = new BowlingFrame(10, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Strike);

			// Assert
			Assert.IsFalse(frame1.IsValid());
			Assert.IsFalse(frame2.IsValid());
			Assert.IsFalse(frame3.IsValid());
			Assert.IsFalse(frame4.IsValid());
			Assert.IsFalse(frame5.IsValid());
			Assert.IsTrue(frame6.IsValid());
			Assert.IsTrue(frame7.IsValid());
			Assert.IsTrue(frame8.IsValid());
		}
	}
}
