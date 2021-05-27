using System.Runtime.Serialization;

namespace TypographyShopBusinessLogic.BindingModels
{
	[DataContract]
	public class StoreFillBindingModel
	{
		[DataMember]
		public StoreBindingModel Model { get; set; }
		[DataMember]
		public int ComponentId { get; set; }
		[DataMember]
		public int Count { get; set; }
	}
}
