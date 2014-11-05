using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class UserAuthenticateModel
	{
        public UserAuthenticateModel()
		{}
		#region Model
		private long _id;
		private long _userid;
		private string _name;
		private string _idcard;
		private string _idpicfront;
		private string _idpicback;
		private DateTime _date;
		private DateTime _completedate;
		private int _state;
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
		public string IDPicFront
		{
			set{ _idpicfront=value;}
			get{return _idpicfront;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDPicBack
		{
			set{ _idpicback=value;}
			get{return _idpicback;}
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
		public int State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

