﻿using System;
using System.Collections.Generic;

namespace TypographyShopBusinessLogic.BindingModels
{
    public class StoreBindingModel
    {
        public int? Id { get; set; }
        public string StoreName { get; set; }
        public string ResponsibleName { get; set; }
        public DateTime DateCreation { get; set; }
        public Dictionary<int, (string, int)> StoreComponents { get; set; }
    }
}
