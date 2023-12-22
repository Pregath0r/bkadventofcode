using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using D1.Input;
using Infrastructure;

namespace D1
{
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [RPlotExporter]
    public class D1
    {
        private readonly InputParser _inputParser;
        private readonly InputParser2 _inputParser2;
        private readonly string[] _input;

        public D1()
        {
            _inputParser = new InputParser();
            _inputParser2 = new InputParser2();
            var assembly = Assembly.GetExecutingAssembly();

            var calibrationInput = new InputReader();
            _input = calibrationInput.GetInput("D1.Input.input.txt", assembly);
        }

        //[Benchmark]
        public void Part1()
        {
            var part1Values = _inputParser2.GetCalibrationValues(_input);
            var part1Result = part1Values.Sum();
            //Console.WriteLine("Part 1 - Result: " + part1Result);
        }


        [Benchmark]
        public void Part2()
        {
            var spelledDigitReplacer = new SpelledDigitReplacer();
            var resolvedInput = spelledDigitReplacer.GetResolvedInput(_input);
            var part2Values = _inputParser2.GetCalibrationValues(resolvedInput);
            var part2Result = part2Values.Sum();
            //Console.WriteLine("Part 2 - Result: " + part2Result);
        }
    }
}