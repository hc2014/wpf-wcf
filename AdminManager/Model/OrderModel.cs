using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class OrderModel
	{
        public OrderModel()
		{}
		#region Model
		private long _id;
        private long _number;
		private long _userid;
		private long _productlogid;
		private string _productname;
		private int _quantity;
		private string _ip;
		private string _describe;
		private string _unit;
		private decimal _prict;
		private DateTime _date;
		private DateTime _completedate;
		private string _page;
		private string _source;
		private string _remark;
		private int _state;
        private decimal _paymoney;
        private decimal _paygold;
        private decimal _paybank;
		private long? _employeeid;
		private decimal? _employeereward;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        public long Number
        {
            set { _number = value; }
            get { return _number; }
        }

        public decimal PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }

        public decimal PayGold
        {
            set { _paygold = value; }
            get { return _paygold; }
        }
        public decimal PayBank
        {
            set { _paybank = value; }
            get { return _paybank; }
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
		public long ProductLogID
		{
            set { _productlogid = value; }
            get { return _productlogid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
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
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _prict=value;}
			get{return _prict;}
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
		public DateTime CompleteDate
		{
			set{ _completedate=value;}
			get{return _completedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Page
		{
			set{ _page=value;}
			get{return _page;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
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
		public long? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? EmployeeReward
		{
			set{ _employeereward=value;}
			get{return _employeereward;}
		}
		#endregion Model

	}
}

