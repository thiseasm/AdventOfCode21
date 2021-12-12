namespace AdventOfCode21.Challenges
{
    public class Day1 : Day
    {
        private readonly int[] _inputs;

        public Day1()
        {
            _inputs = ReadIntegerFile("Day1.txt");
        }

        public override void Start()
        {
            var firstProduct = ExecuteFirstPart();
            var secondProduct = ExecuteSecondPart();

            Console.WriteLine($"The times the depth increases is: {firstProduct}");
            Console.WriteLine($"The product of the three numbers is: {secondProduct}");
        }

        private int ExecuteSecondPart()
        {
            var timesDepthIncreases = 0;
            var windows = new List<int>();
            

            for (int counter = 0; counter < _inputs.Length - 2; counter++)
            { 
                if(_inputs.Length - counter < 2)
                {
                    break;
                }

                var window = _inputs[counter] + _inputs[counter+1] + _inputs[counter + 2];
                windows.Add(window);
            }

            for(int counter = 1; counter < windows.Count; counter++)
            {
                if(windows[counter] > windows[counter - 1])
                {
                    timesDepthIncreases++;
                }
            }


            return timesDepthIncreases;
        }

        private int ExecuteFirstPart()
        {
            var timesDepthIncreases = 0;
            
            for(int counter = 1; counter < _inputs.Length; counter++)
            {
                if(_inputs[counter] > _inputs[counter - 1])
                {
                    timesDepthIncreases++;
                }
            }
            
            return timesDepthIncreases;

        }
    }
}
