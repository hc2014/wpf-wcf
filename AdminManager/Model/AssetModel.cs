using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class AssetModel
	{
        public AssetModel()
		{}
		#region Model
		private long _id;
		private long _userid;
		private decimal _money=0M;
		private decimal _gold=0M;
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
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Gold
		{
			set{ _gold=value;}
			get{return _gold;}
		}
		#endregion Model

	}
}

