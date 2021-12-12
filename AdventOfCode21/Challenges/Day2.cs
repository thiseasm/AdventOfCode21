namespace AdventOfCode21.Challenges
{
    public class Day2 : Day
    {
        private readonly string[] _inputs;

        public Day2()
        {
            _inputs = ReadFile("Day2.txt");
        }

        public override void Start()
        {
            var firstProduct = ExecuteFirstPart();
            var secondProduct = ExecuteSecondPart();

            Console.WriteLine($"Multiplying depth and position produces: {firstProduct}");
            Console.WriteLine($"Multiplying using AIM produces: {secondProduct}");
        }

        private int ExecuteFirstPart()
        {
            var position = 0;
            var depth = 0;

            foreach(var input in _inputs)
            {
                var command = input.Split(' ');
                var amount = int.Parse(command[1]);
                switch (command[0])
                {
                    case "forward":
                        position += amount;
                        break;
                    case "down":
                        depth += amount;
                        break;
                    case "up":
                        depth -= amount;
                        break;
                }
            }

            return position * depth;
        }

        private int ExecuteSecondPart()
        {
            var position = 0;
            var depth = 0;
            var aim = 0;

            foreach (var input in _inputs)
            {
                var command = input.Split(' ');
                var amount = int.Parse(command[1]);
                switch (command[0])
                {
                    case "forward":
                        position += amount;
                        depth += amount * aim;
                        break;
                    case "down":
                        aim += amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                }
            }

            return position * depth;
        }
    }
}
