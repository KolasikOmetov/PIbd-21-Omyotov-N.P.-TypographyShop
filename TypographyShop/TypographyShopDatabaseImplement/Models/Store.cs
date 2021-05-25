﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypographyShopDatabaseImplement.Models
{
	/// <summary>
	/// Склад с компонентами
	/// </summary>
	public class Store
	{
		public int Id { get; set; }
		[Required]
		public string StoreName { get; set; }
		[Required]
		public string ResponsibleName { get; set; }
		[Required]
		public DateTime DateCreation { get; set; }
		[ForeignKey("StoreId")]
		public virtual List<StoreComponent> StoreComponents { get; set; }
	}
}