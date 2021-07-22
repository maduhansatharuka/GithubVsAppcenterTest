using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Test.Models
{
    public class STRootModel
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<StockTransferModel> Data { get; set; }
        public STSuportModel STSuportModel { get; set; }
    }
}
