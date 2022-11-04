namespace Speed.Client
{
    public class StateContainer
    {
        private int hard = 0;
        private int time = 30;
        private int timer = 30;
        private double firstCharPosition = 0;
        private double nextCharPositionDifference = 37.5;
        private int accuracy = 0;
        private int wpm = 0;
        private int errors = 0;

        public int Difficulty
        {
            get => hard;
            set => hard = value;
        }

        public int Duration
        {
            get => time;
            set { time = value; timer = value; }
        }

        public int Timer
        {
            get => timer;
            set => timer = value;
        }

        public double FirstCharPosition
        {
            get => firstCharPosition;
            set => firstCharPosition = value;
        }

        public double PositionDifference
        {
            get => nextCharPositionDifference;
            set => nextCharPositionDifference = value;
        }

        public int Accuracy
        {
            get => accuracy;
            set => accuracy = value;
        }

        public int WPM
        {
            get => wpm;
            set => wpm = value;
        }
        
        public int Error
        {
            get => errors;
            set => errors = value;
        }
    }
}
