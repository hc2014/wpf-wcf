using System;
namespace AdminManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class SystemParameterModel
	{
        public SystemParameterModel()
		{}
		#region Model
		private string _id;
		private int _type;
		private string _name;
		private string _order;
		private int _state;
		private string _parentid;
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
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order
		{
			set{ _order=value;}
			get{return _order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

