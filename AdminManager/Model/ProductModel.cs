using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class ProductModel
	{
        public ProductModel()
		{}
		#region Model
		private long _id;
		private string _name;
		private decimal _price;
		private string _describe;
		private int _type;
		private string _content;
		private string _remark;
		private int _state=0;
		private int _exp=0;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Describe
		{
			set{ _describe=value;}
			get{return _describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Exp
		{
			set{ _exp=value;}
			get{return _exp;}
		}
		#endregion Model

	}
}

