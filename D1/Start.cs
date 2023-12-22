using BenchmarkDotNet.Running;

namespace D1
{
    public class Start
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<D1>();
        }
    }
}