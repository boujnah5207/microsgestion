﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blackspot.Microgestion.Backend.Entities
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class MicrogestionDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertMenuOption(MenuOption instance);
    partial void UpdateMenuOption(MenuOption instance);
    partial void DeleteMenuOption(MenuOption instance);
    partial void InsertRole(Role instance);
    partial void UpdateRole(Role instance);
    partial void DeleteRole(Role instance);
    partial void InsertRoleAction(RoleAction instance);
    partial void UpdateRoleAction(RoleAction instance);
    partial void DeleteRoleAction(RoleAction instance);
    partial void InsertUserRoles(UserRoles instance);
    partial void UpdateUserRoles(UserRoles instance);
    partial void DeleteUserRoles(UserRoles instance);
    #endregion
		
		public MicrogestionDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MicrogestionDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MicrogestionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MicrogestionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<MenuOption> MenuOptions
		{
			get
			{
				return this.GetTable<MenuOption>();
			}
		}
		
		public System.Data.Linq.Table<Role> Roles
		{
			get
			{
				return this.GetTable<Role>();
			}
		}
		
		public System.Data.Linq.Table<RoleAction> RoleActions
		{
			get
			{
				return this.GetTable<RoleAction>();
			}
		}
		
		public System.Data.Linq.Table<UserRoles> UserRoles
		{
			get
			{
				return this.GetTable<UserRoles>();
			}
		}
	}
	
	[Table(Name="")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private string _Username;
		
		private string _Password;
		
		private string _Name;
		
		private string _LastName;
		
		private EntitySet<UserRoles> _UserRoles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    #endregion
		
		public User()
		{
			this._UserRoles = new EntitySet<UserRoles>(new Action<UserRoles>(this.attach_UserRoles), new Action<UserRoles>(this.detach_UserRoles));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, UpdateCheck=UpdateCheck.Never)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Username", DbType="nvarchar(50)", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="nvarchar(50)", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="nvarchar(50)", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_LastName", DbType="nvarchar(50)", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[Association(Name="User_UserRoles", Storage="_UserRoles", ThisKey="ID", OtherKey="UserID")]
		internal EntitySet<UserRoles> UserRoles
		{
			get
			{
				return this._UserRoles;
			}
			set
			{
				this._UserRoles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[Table(Name="")]
	public partial class MenuOption : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private System.Nullable<System.Guid> _ParentID;
		
		private string _Text;
		
		private int _ActionID;
		
		private int _Order;
		
		private EntitySet<MenuOption> _Childs;
		
		private EntityRef<MenuOption> _Parent;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnParentIDChanging(System.Nullable<System.Guid> value);
    partial void OnParentIDChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnActionIDChanging(int value);
    partial void OnActionIDChanged();
    partial void OnOrderChanging(int value);
    partial void OnOrderChanged();
    #endregion
		
		public MenuOption()
		{
			this._Childs = new EntitySet<MenuOption>(new Action<MenuOption>(this.attach_Childs), new Action<MenuOption>(this.detach_Childs));
			this._Parent = default(EntityRef<MenuOption>);
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, UpdateCheck=UpdateCheck.Never)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_ParentID")]
		public System.Nullable<System.Guid> ParentID
		{
			get
			{
				return this._ParentID;
			}
			set
			{
				if ((this._ParentID != value))
				{
					if (this._Parent.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentIDChanging(value);
					this.SendPropertyChanging();
					this._ParentID = value;
					this.SendPropertyChanged("ParentID");
					this.OnParentIDChanged();
				}
			}
		}
		
		[Column(Storage="_Text", DbType="nvarchar(20)", CanBeNull=false)]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[Column(Storage="_ActionID")]
		private int ActionID
		{
			get
			{
				return this._ActionID;
			}
			set
			{
				if ((this._ActionID != value))
				{
					this.OnActionIDChanging(value);
					this.SendPropertyChanging();
					this._ActionID = value;
					this.SendPropertyChanged("ActionID");
					this.OnActionIDChanged();
				}
			}
		}
		
		[Column(Storage="_Order")]
		public int Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this.OnOrderChanging(value);
					this.SendPropertyChanging();
					this._Order = value;
					this.SendPropertyChanged("Order");
					this.OnOrderChanged();
				}
			}
		}
		
		[Association(Name="MenuOption_MenuOption", Storage="_Childs", ThisKey="ID", OtherKey="ParentID")]
		public EntitySet<MenuOption> Childs
		{
			get
			{
				return this._Childs;
			}
			set
			{
				this._Childs.Assign(value);
			}
		}
		
		[Association(Name="MenuOption_MenuOption", Storage="_Parent", ThisKey="ParentID", OtherKey="ID", IsForeignKey=true)]
		public MenuOption Parent
		{
			get
			{
				return this._Parent.Entity;
			}
			set
			{
				MenuOption previousValue = this._Parent.Entity;
				if (((previousValue != value) 
							|| (this._Parent.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Parent.Entity = null;
						previousValue.Childs.Remove(this);
					}
					this._Parent.Entity = value;
					if ((value != null))
					{
						value.Childs.Add(this);
						this._ParentID = value.ID;
					}
					else
					{
						this._ParentID = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("Parent");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Childs(MenuOption entity)
		{
			this.SendPropertyChanging();
			entity.Parent = this;
		}
		
		private void detach_Childs(MenuOption entity)
		{
			this.SendPropertyChanging();
			entity.Parent = null;
		}
	}
	
	[Table(Name="")]
	public partial class Role : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private string _Name;
		
		private EntitySet<RoleAction> _Actions;
		
		private EntitySet<UserRoles> _UserRoles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Role()
		{
			this._Actions = new EntitySet<RoleAction>(new Action<RoleAction>(this.attach_Actions), new Action<RoleAction>(this.detach_Actions));
			this._UserRoles = new EntitySet<UserRoles>(new Action<UserRoles>(this.attach_UserRoles), new Action<UserRoles>(this.detach_UserRoles));
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, UpdateCheck=UpdateCheck.Never)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="nvarchar(50)", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Association(Name="Role_RoleAction", Storage="_Actions", ThisKey="ID", OtherKey="RoleID")]
		public EntitySet<RoleAction> Actions
		{
			get
			{
				return this._Actions;
			}
			set
			{
				this._Actions.Assign(value);
			}
		}
		
		[Association(Name="Role_UserRoles", Storage="_UserRoles", ThisKey="ID", OtherKey="RoleID")]
		internal EntitySet<UserRoles> UserRoles
		{
			get
			{
				return this._UserRoles;
			}
			set
			{
				this._UserRoles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Actions(RoleAction entity)
		{
			this.SendPropertyChanging();
			entity.Role = this;
		}
		
		private void detach_Actions(RoleAction entity)
		{
			this.SendPropertyChanging();
			entity.Role = null;
		}
		
		private void attach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Role = this;
		}
		
		private void detach_UserRoles(UserRoles entity)
		{
			this.SendPropertyChanging();
			entity.Role = null;
		}
	}
	
	[Table(Name="")]
	public partial class RoleAction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _RoleID;
		
		private int _ActionID;
		
		private EntityRef<Role> _Role;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoleIDChanging(System.Guid value);
    partial void OnRoleIDChanged();
    partial void OnActionIDChanging(int value);
    partial void OnActionIDChanged();
    #endregion
		
		public RoleAction()
		{
			this._Role = default(EntityRef<Role>);
			OnCreated();
		}
		
		[Column(Storage="_RoleID", IsPrimaryKey=true)]
		public System.Guid RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					if (this._Role.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleIDChanging(value);
					this.SendPropertyChanging();
					this._RoleID = value;
					this.SendPropertyChanged("RoleID");
					this.OnRoleIDChanged();
				}
			}
		}
		
		[Column(Storage="_ActionID", IsPrimaryKey=true)]
		private int ActionID
		{
			get
			{
				return this._ActionID;
			}
			set
			{
				if ((this._ActionID != value))
				{
					this.OnActionIDChanging(value);
					this.SendPropertyChanging();
					this._ActionID = value;
					this.SendPropertyChanged("ActionID");
					this.OnActionIDChanged();
				}
			}
		}
		
		[Association(Name="Role_RoleAction", Storage="_Role", ThisKey="RoleID", OtherKey="ID", IsForeignKey=true)]
		public Role Role
		{
			get
			{
				return this._Role.Entity;
			}
			set
			{
				Role previousValue = this._Role.Entity;
				if (((previousValue != value) 
							|| (this._Role.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Role.Entity = null;
						previousValue.Actions.Remove(this);
					}
					this._Role.Entity = value;
					if ((value != null))
					{
						value.Actions.Add(this);
						this._RoleID = value.ID;
					}
					else
					{
						this._RoleID = default(System.Guid);
					}
					this.SendPropertyChanged("Role");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="")]
	public partial class UserRoles : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _UserID;
		
		private System.Guid _RoleID;
		
		private EntityRef<User> _User;
		
		private EntityRef<Role> _Role;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(System.Guid value);
    partial void OnUserIDChanged();
    partial void OnRoleIDChanging(System.Guid value);
    partial void OnRoleIDChanged();
    #endregion
		
		public UserRoles()
		{
			this._User = default(EntityRef<User>);
			this._Role = default(EntityRef<Role>);
			OnCreated();
		}
		
		[Column(Storage="_UserID", IsPrimaryKey=true)]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_RoleID", IsPrimaryKey=true)]
		public System.Guid RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					if (this._Role.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleIDChanging(value);
					this.SendPropertyChanging();
					this._RoleID = value;
					this.SendPropertyChanged("RoleID");
					this.OnRoleIDChanged();
				}
			}
		}
		
		[Association(Name="User_UserRoles", Storage="_User", ThisKey="UserID", OtherKey="ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.UserRoles.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.UserRoles.Add(this);
						this._UserID = value.ID;
					}
					else
					{
						this._UserID = default(System.Guid);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[Association(Name="Role_UserRoles", Storage="_Role", ThisKey="RoleID", OtherKey="ID", IsForeignKey=true)]
		public Role Role
		{
			get
			{
				return this._Role.Entity;
			}
			set
			{
				Role previousValue = this._Role.Entity;
				if (((previousValue != value) 
							|| (this._Role.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Role.Entity = null;
						previousValue.UserRoles.Remove(this);
					}
					this._Role.Entity = value;
					if ((value != null))
					{
						value.UserRoles.Add(this);
						this._RoleID = value.ID;
					}
					else
					{
						this._RoleID = default(System.Guid);
					}
					this.SendPropertyChanged("Role");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
