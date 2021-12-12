namespace AdventOfCode21.Challenges
{
    public class Day3 : Day
    {
        private readonly string[] _inputs;

        public Day3()
        {
            _inputs = ReadFile("Day3.txt");
        }

        public override void Start()
        {
            var firstProduct = ExecuteFirstPart();
            var secondProduct = ExecuteSecondPart();

            Console.WriteLine($"Power Consumption: {firstProduct}");
            Console.WriteLine($"Life Support Rating: {secondProduct}");
        }

        private int ExecuteFirstPart()
        {
            var gammaBinary = string.Empty;
            var epsilonBinary = string.Empty;

            for (int counter = 0; counter < _inputs[0].Length; counter++)
            {
                var isOne = _inputs.Where(i => i[counter] == '1').Count() > _inputs.Length/2;

                if (isOne)
                {
                    gammaBinary += "1";
                    epsilonBinary += "0";
                }
                else
                {
                    gammaBinary += "0";
                    epsilonBinary += "1";
                }
            }

            var gamma =  Convert.ToInt32(gammaBinary, 2);
            var epsilon = Convert.ToInt32(epsilonBinary, 2);

            return gamma * epsilon;
        }

        private int ExecuteSecondPart()
        {   
            var oxygenCandidates = _inputs;
            var counter = 0;

            while (oxygenCandidates.Length > 1)
            {
                var isOne = oxygenCandidates.Where(i => i[counter] == '1').Count() >= oxygenCandidates.Where(i => i[counter] == '0').Count();

                if (isOne)
                {
                    oxygenCandidates = oxygenCandidates.Where(i => i[counter] == '1').ToArray();
                }
                else
                {
                    oxygenCandidates = oxygenCandidates.Where(i => i[counter] == '0').ToArray();
                }

                counter++;
            }

            var oxygenBinary = oxygenCandidates.First();

            var co2Candidates = _inputs;
            counter = 0;

            while (co2Candidates.Length > 1)
            {
                var isOne = co2Candidates.Where(i => i[counter] == '1').Count() < co2Candidates.Where(i => i[counter] == '0').Count();

                if (isOne)
                {
                    co2Candidates = co2Candidates.Where(i => i[counter] == '1').ToArray();
                }
                else
                {
                    co2Candidates = co2Candidates.Where(i => i[counter] == '0').ToArray();
                }

                counter++;
            }

            var cO2Binary = co2Candidates.First();

            var oxygen = Convert.ToInt32(oxygenBinary, 2);
            var co2 = Convert.ToInt32(cO2Binary, 2);

            return oxygen * co2;
        }
    }
}
