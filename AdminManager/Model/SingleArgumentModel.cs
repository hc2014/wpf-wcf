using System;
namespace AdminManager.Model
{
	/// <summary>
	/// refactoring log
	/// </summary>
	[Serializable]
	public partial class SingleArgumentModel
	{
        public SingleArgumentModel()
		{}
		#region Model
		private string _id;
		private string _staffid;
		private string _staffname;
		private int? _type;
		private string _fieldname;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string staffid
		{
			set{ _staffid=value;}
			get{return _staffid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string staffname
		{
			set{ _staffname=value;}
			get{return _staffname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fieldname
		{
			set{ _fieldname=value;}
			get{return _fieldname;}
		}
		#endregion Model

	}
}

