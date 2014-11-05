using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class AssetLogModel
	{
        public AssetLogModel()
		{}
		#region Model
		private long _id;
		private long _assetid;
		private decimal _money;
		private decimal _gold;
		private string _logreason;
		private DateTime _logdate= DateTime.Now;
		private long? _logoperator;
		private int? _logtype;
		private long? _logpointer;
		private string _logip;
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
		public long AssetID
		{
			set{ _assetid=value;}
			get{return _assetid;}
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
		/// <summary>
		/// 
		/// </summary>
		public string logReason
		{
			set{ _logreason=value;}
			get{return _logreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime logDate
		{
			set{ _logdate=value;}
			get{return _logdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? logOperator
		{
			set{ _logoperator=value;}
			get{return _logoperator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? logType
		{
			set{ _logtype=value;}
			get{return _logtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? logPointer
		{
			set{ _logpointer=value;}
			get{return _logpointer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logIP
		{
			set{ _logip=value;}
			get{return _logip;}
		}
		#endregion Model

	}
}

