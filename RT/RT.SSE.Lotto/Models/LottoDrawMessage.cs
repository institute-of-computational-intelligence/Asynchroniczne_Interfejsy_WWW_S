using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT.SSE.Lotto.Models
{
    public class LottoDrawMessage
    {
        public DateTime DrawTimestamp { get; set; }
        public int Nr1 { get; set; }
        public int Nr2 { get; set; }
        public int Nr3 { get; set; }
        public int Nr4 { get; set; }
        public int Nr5 { get; set; }
        public int Nr6 { get; set; }
    }
}
