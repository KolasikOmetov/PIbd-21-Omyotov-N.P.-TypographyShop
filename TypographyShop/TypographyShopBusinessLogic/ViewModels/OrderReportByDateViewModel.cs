﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyShopBusinessLogic.ViewModels
{
    public class OrderReportByDateViewModel
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
