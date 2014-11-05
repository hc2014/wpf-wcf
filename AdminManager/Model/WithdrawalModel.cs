using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class WithdrawalModel
	{
        public WithdrawalModel()
		{}
		#region Model
		private long _id;
		private long _userid;
		private long _assetid;
		private decimal _money;
		private DateTime _date;
		private DateTime? _completedate;
		private string _name;
		private string _banktype;
		private string _bankcode;
		private int _state=0;
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
		public DateTime Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CompleteDate
		{
			set{ _completedate=value;}
			get{return _completedate;}
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
		public string BankType
		{
			set{ _banktype=value;}
			get{return _banktype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankCode
		{
			set{ _bankcode=value;}
			get{return _bankcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

