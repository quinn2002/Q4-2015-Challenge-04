namespace CodeChallenge04_BowlingScorer
{
	public class BowlingFrame
	{
		// properties
		public SingleBallScoreEnum Ball1 { get; private set; }
		public SingleBallScoreEnum Ball2 { get; private set; }
		public SingleBallScoreEnum Ball3 { get; private set; }
		public int FrameNumber { get; private set; }

		// constructor
		public BowlingFrame(int frameNumber, SingleBallScoreEnum ball1, SingleBallScoreEnum ball2, SingleBallScoreEnum ball3)
		{
			Ball1 = ball1;
			Ball2 = ball2;
			Ball3 = ball3;
			FrameNumber = frameNumber;
		}
	}
}