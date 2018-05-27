using System;

namespace MvcPerfTest
{
    public class Test
    {
        public int Id { get; set; }
        public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset End { get; set; }
    }
}