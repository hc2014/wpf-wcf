using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class EmployeeModel
	{
        public EmployeeModel()
		{}
		#region Model
		private long _id;
		private long _userid;
		private long? _employeegroupid;
		private string _name;
		private string _idcard;
		private string _email;
		private string _qq;
		private string _telephone;
		private string _mobile;
		private string _homeaddress;
		private string _address;
		private string _remark;
		private DateTime? _birthday;
		private string _banktype;
		private string _bankcode;
		private decimal _salary=0M;
		private string _authorization;
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
		public long? EmployeeGroupID
		{
			set{ _employeegroupid=value;}
			get{return _employeegroupid;}
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
		public string IDCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeAddress
		{
			set{ _homeaddress=value;}
			get{return _homeaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
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
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
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
		public decimal Salary
		{
			set{ _salary=value;}
			get{return _salary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Authorization
		{
			set{ _authorization=value;}
			get{return _authorization;}
		}
		#endregion Model

	}
}

