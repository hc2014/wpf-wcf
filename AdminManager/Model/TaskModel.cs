using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TaskModel
	{
		public TaskModel()
		{}
		#region Model
		private long _id;
		private string _title;
		private string _describe;
		private DateTime? _completedate;
        private DateTime _date;
		private int _level;
		private int _type;
		private long? _pointer;
		private int _state=0;
        private long? _employeeid;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        public long? EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		public DateTime? CompleteDate
		{
			set{ _completedate=value;}
			get{return _completedate;}
		}
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int Level
		{
			set{ _level=value;}
			get{return _level;}
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
		public long? Pointer
		{
			set{ _pointer=value;}
			get{return _pointer;}
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

