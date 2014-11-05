using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UserModel
	{
        public UserModel()
		{}
		#region Model
		private long _id;
		private long? _parentid;
		private long _number;
		private string _account;
		private string _nickname;
		private string _password;
		private string _parentpassword;
		private string _email;
		private string _mobile;
		private string _qq;
		private bool _gender;
		private DateTime? _birthday;
		private bool _islunar;
		private int _experience=0;
		private int _integral=0;
		private int _bagsize=0;
		private long _head=0;
		private string _feel="开心";
		private Guid _rememberpwdid;
		private string _ip;
		private DateTime _registerdate= DateTime.Now;
		private int _type=0;
		private int _state=1;
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
		public long? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentPassword
		{
			set{ _parentpassword=value;}
			get{return _parentpassword;}
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
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		public bool Gender
		{
			set{ _gender=value;}
			get{return _gender;}
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
		public bool IsLunar
		{
			set{ _islunar=value;}
			get{return _islunar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Experience
		{
			set{ _experience=value;}
			get{return _experience;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BagSize
		{
			set{ _bagsize=value;}
			get{return _bagsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long Head
		{
			set{ _head=value;}
			get{return _head;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Feel
		{
			set{ _feel=value;}
			get{return _feel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid RememberPwdID
		{
			set{ _rememberpwdid=value;}
			get{return _rememberpwdid;}
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
		public DateTime RegisterDate
		{
			set{ _registerdate=value;}
			get{return _registerdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
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

